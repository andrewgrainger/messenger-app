using MediatR;
using Room.Application.Responses;
using Room.Domain.Pagination;

namespace Room.Application.Queries;

public record GetRoomsByUsernameQuery(string UserName, int PageIndex, int PageSize) : IRequest<PaginatedList<RoomResponse>>;