using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using OSCManager.Abstractions.Condition;
using OSCManager.Persistence.Core.Entities;

namespace OSCManager.Persistence.Core.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext context)
        {
            _dbContext = context;
        }

        public Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task AddManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteManyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> expression, OrderBy<T> orderBy = null, Paging paging = null, CancellationToken cancellationToken = default)
        {
            var dbSet = _dbContext.Set<T>();
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
                queryable = queryable.Skip(paging.Skip).Take(paging.Take);

            throw new NotImplementedException();
        }

        public Task SaveAsync(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected async ValueTask DoWork(Func<DbContext, ValueTask> work, CancellationToken cancellationToken)
        {
            await work(_dbContext);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
