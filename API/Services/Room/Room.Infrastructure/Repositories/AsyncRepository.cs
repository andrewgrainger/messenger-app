using System.Linq.Expressions;
using Room.Domain.Common;
using Room.Domain.Repositories;
using Room.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Room.Infrastructure.Repositories;

public class AsyncRepository<T>(RoomsDbContext roomDbContext) : IAsyncRepository<T> where T : GuidEntity
{
    private readonly RoomsDbContext _roomDbContext = roomDbContext;

    public async Task<bool> AddAsync(T entity)
    {
        _roomDbContext.Set<T>().Add(entity);
        return await _roomDbContext.SaveChangesAsync() > 0;
    }

    public async Task DeleteAsync(T entity)
    {
        _roomDbContext.Set<T>().Remove(entity);
        await _roomDbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _roomDbContext.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await _roomDbContext.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _roomDbContext.Set<T>().FindAsync(id);
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _roomDbContext.Entry(entity).State = EntityState.Modified;
        return await _roomDbContext.SaveChangesAsync() > 0;
    }

}