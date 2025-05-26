using System.Linq.Expressions;
using WebProject.Domains;

namespace WebProject.Repositories;

public interface ICommandRepository<TEntity, in TId> : IRepository
    where TEntity : AggregateRoot
    where TId : notnull
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    Task DeleteAsync(TEntity entity);

    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity entity);

    Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken = default);

    IQueryable<TEntity> GetAll();

    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}
