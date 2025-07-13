using System.Linq.Expressions;
using Room.Domain.Common;

namespace Room.Domain.Repositories;

public interface IAsyncRepository<T> where T : GuidEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<T?> GetByIdAsync(Guid id);
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync (T entity);
    Task DeleteAsync(T entity);
}