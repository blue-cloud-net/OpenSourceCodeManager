using System.Linq.Expressions;

using OSCManager.Persistence.Core.Extensions;

namespace OSCManager.Persistence.Core.Repository;

public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    // 解决并发的信号量锁
    private readonly SemaphoreSlim _semaphore = new(1);

    public BaseRepository(DbContext context, IMapper mapper, ILogger logger)
    {
        _dbContext = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task SaveAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _semaphore.WaitAsync(cancellationToken);

        try
        {
            await this.DoWork(async dbContext =>
            {
                var dbSet = dbContext.Set<T>();
                var existingEntity = await dbSet.FindAsync(new object[] { entity.Id }, cancellationToken);

                if (existingEntity == null)
                {
                    await dbSet.AddAsync(entity, cancellationToken);
                    existingEntity = entity;
                }
                else
                {
                    // Can't use the approach on the next line because we explicitly ignore certain properties (in order for them to be stored in the Data shadow property).
                    // dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

                    // Therefore using AutoMapper to copy properties instead.
                    existingEntity = _mapper.Map(entity, existingEntity);
                }
            }, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Save Failed!");
            throw;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await this.DoWork(async dbContext =>
        {
            var dbSet = dbContext.Set<T>();
            await dbSet.AddAsync(entity, cancellationToken);
        }, cancellationToken);
    }

    public async Task AddManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        var list = entities.ToList();

        if (!list.Any())
        {
            return;
        }

        await this.DoWork(async dbContext =>
        {
            var dbSet = dbContext.Set<T>();
            await dbSet.AddRangeAsync(list, cancellationToken);
        }, cancellationToken);
    }
    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await this.DoWork(dbContext =>
        {
            var dbSet = dbContext.Set<T>();
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }, cancellationToken);
    }
    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        await this.DoWork(async dbContext =>
            await dbContext.Set<T>().AsQueryable().Where(x => x.Id == entity.Id)
            .BatchDeleteWithWorkAroundAsync(dbContext, cancellationToken),
         cancellationToken);
    }

    public async Task<int> DeleteManyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await this.DoWork(async dbContext =>
              await dbContext.Set<T>().Where(expression).BatchDeleteWithWorkAroundAsync(dbContext, cancellationToken), cancellationToken
         );
    }
    public async Task<T?> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await this.DoWork(async dbContext =>
        {
            var dbSet = dbContext.Set<T>();
            return await dbSet.FirstOrDefaultAsync(expression, cancellationToken);
        }, cancellationToken);
    }

    public async Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> expression, Paging? paging = null, OrderBy<T>? orderBy = null, CancellationToken cancellationToken = default)
    {
        return await this.DoWork(async dbContext =>
        {
            var dbSet = dbContext.Set<T>();
            var queryable = dbSet.Where(expression);

            if (orderBy is not null)
            {
                foreach (var item in orderBy.Sorts)
                {
                    var orderByExpression = item.OrderByExpression;
                    queryable = item.SortDirection == SortDirection.Ascending ? queryable.OrderBy(orderByExpression) : queryable.OrderByDescending(orderByExpression);
                }
            }

            if (paging != null)
            {
                queryable = queryable.Skip(paging.Skip).Take(paging.Take);
            }

            return (await queryable.ToListAsync(cancellationToken)).ToList();
        }, cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await this.DoWork(async dbContext =>
        {
            var dbSet = dbContext.Set<T>();
            return await dbSet.CountAsync(expression, cancellationToken);
        }, cancellationToken);
    }

    protected async ValueTask DoWork(Func<DbContext, ValueTask> work, CancellationToken cancellationToken)
    {
        await work(_dbContext);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    protected async ValueTask DoWork(Action<DbContext> work, CancellationToken cancellationToken)
    {
        work(_dbContext);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    protected async ValueTask<TResult> DoWork<TResult>(Func<DbContext, ValueTask<TResult>> work, CancellationToken cancellationToken)
    {
        var result = await work(_dbContext);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return result;
    }
}
