using Room.Domain.Entities;
using Room.Domain.Repositories;
using Room.Infrastructure.Data;
using Room.Domain.Pagination;
using Microsoft.EntityFrameworkCore;
using Room.Application.Mappers;

namespace Room.Infrastructure.Repositories;

public class RoomRepository(RoomsDbContext roomsDbContext) : AsyncRepository<Rooms>(roomsDbContext), IRoomRepository
{
    protected readonly RoomsDbContext _roomsDbContext = roomsDbContext;

    public async Task<PaginatedList<Rooms>> GetRoomsByUsername(string userName, int pageIndex, int pageSize)
    {
        var roomsByUsernameQuery = GetRoomsByUsernameQuery(userName);
        
        var totalRooms = await roomsByUsernameQuery.CountAsync();
        var rooms = await roomsByUsernameQuery
            .OrderByDescending(x => x.LastMessage.Timestamp)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return rooms.ToPaginatedList(totalRooms, pageIndex, pageSize);
    }

    public IQueryable<Rooms> GetRoomsByUsernameQuery(string userName)
    {
        return _roomsDbContext.Rooms
            .Include(r => r.Users)
            .Include(r => r.LastMessage)
            .Where(room => room.Users != null && room.Users.Any(users => users.UserName.Contains(userName)))
            .AsNoTracking()
            .AsQueryable();
    }
}