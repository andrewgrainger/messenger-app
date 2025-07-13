using Room.Domain.Entities;
using Room.Domain.Pagination;

namespace Room.Domain.Repositories;

public interface IRoomRepository : IAsyncRepository<Rooms>
{
    Task<PaginatedList<Rooms>> GetRoomsByUsername(string userName, int pageIndex, int pageSize);
    IQueryable<Rooms> GetRoomsByUsernameQuery(string userName);
}
