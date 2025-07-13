using AutoMapper;
using MediatR;
using Room.Application.Queries;
using Room.Application.Responses;
using Room.Domain.Entities;
using Room.Domain.Pagination;
using Room.Domain.Repositories;

namespace Room.Application.Handlers;

internal sealed class GetChatMessagesByChatIdQueryHandler(IRoomRepository chatRepository, IMapper mapper) : IRequestHandler<GetRoomsByUsernameQuery, PaginatedList<RoomResponse>>
{
    private readonly IRoomRepository _roomRepository = chatRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<RoomResponse>> Handle(GetRoomsByUsernameQuery request, CancellationToken cancellationToken)
    {
        PaginatedList<Rooms> userRooms = await _roomRepository.GetRoomsByUsername(request.UserName, request.PageIndex, request.PageSize);
        return _mapper.Map<PaginatedList<RoomResponse>>(userRooms);
    }
}