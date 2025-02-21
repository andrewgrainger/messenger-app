using System.Linq.Expressions;
using Messenger.Application.Exceptions;
using Messenger.Domain.Common;
using Messenger.Domain.Repositories;
using Messenger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Infrastructure.Repositories;

public class AsyncRepository<T>(ChatDbContext chatDbContext) : IAsyncRepository<T> where T : GuidEntity
{
    private readonly ChatDbContext _chatDbContext = chatDbContext;

    public async Task<T> AddAsync(T entity)
    {
        _chatDbContext.Set<T>().Add(entity);
        await _chatDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _chatDbContext.Set<T>().Remove(entity);
        await _chatDbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _chatDbContext.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await _chatDbContext.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _chatDbContext.Set<T>().FindAsync(id) ?? throw new ChatNotFoundException("Chat Not Found", id);
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _chatDbContext.Entry(entity).State = EntityState.Modified;
        return await _chatDbContext.SaveChangesAsync() > 0;
    }

}
