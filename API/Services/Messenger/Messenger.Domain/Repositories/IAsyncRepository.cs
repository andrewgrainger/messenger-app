using System.Linq.Expressions;
using Messenger.Domain.Common;

namespace Messenger.Domain.Repositories;

public interface IAsyncRepository<T> where T : GuidEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task<bool> UpdateAsync (T entity);
    Task DeleteAsync(T entity);
}
