using System.Linq.Expressions;

namespace OSCManager.Abstractions.Persistence;

public interface IRepository<T> where T : IEntity
{
    Task SaveAsync(T entity, CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task AddManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<int> DeleteManyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> expression, Paging? paging = null, OrderBy<T>? orderBy = null, CancellationToken cancellationToken = default);
    Task<int> CountAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T?> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
}
