using AutoMapper;
using Room.Application.Responses;
using Room.Domain.Entities;
using Room.Domain.Pagination;

namespace Room.Application.Mappers;

public class RoomMappingProfile : Profile
{
    public RoomMappingProfile()
    {
        CreateMap<Rooms, RoomResponse>()
            .ReverseMap();
        CreateMap<Rooms, RoomResponse>()
            .ReverseMap();
        CreateMap<RoomUser, RoomUserResponse>()
            .ReverseMap();
        CreateMap<UserStatus, UserStatusResponse>()
            .ReverseMap();
        CreateMap<LastMessage, LastMessageResponse>()
            .ReverseMap();
        CreateMap<MessageFile, MessageFileResponse>()
            .ReverseMap();
        CreateMap<PaginatedList<Rooms>, PaginatedList<RoomResponse>>()
            .ReverseMap();
    }
}