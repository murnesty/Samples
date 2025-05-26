using System.Linq.Expressions;
using WebProject.Domains;

namespace WebProject.Repositories;

public interface IQueryRepository<TEntity> where TEntity : Entity
{
    Task<bool> ExistsAsync(
        Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default);

    Task<TEntity> FirstAsync(
        Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default);

    Task<TEntity> SingleAsync(
        Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default);

    IQueryable<TEntity> GetAll();

    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
}
