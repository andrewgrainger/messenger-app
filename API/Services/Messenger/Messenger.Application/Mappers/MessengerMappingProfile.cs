using AutoMapper;
using Messenger.Application.Commands;
using Messenger.Application.Responses;
using Messenger.Domain.Entities;
using Messenger.Domain.Pagination;

namespace Messenger.Application.Mappers;

public class MessengerMappingProfile : Profile
{
    public MessengerMappingProfile()
    {
        CreateMap<Chat, ChatResponse>().ReverseMap();
        CreateMap<Chat, CreateChatCommand>().ReverseMap()
            .ForMember(d => d.ChatUsers, o => 
                o.MapFrom(s => s.UserIds
                                .Select(userId => new ChatUser { UserId = userId })
                                .ToList()));
        CreateMap<Message, MessageResponse>().ReverseMap();
        CreateMap<PaginatedList<Message>, PaginatedList<MessageResponse>>().ReverseMap();
        CreateMap<Message, CreateMessageCommand>().ReverseMap();
    }
}
