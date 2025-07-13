using AutoMapper;
using MediatR;
using Messenger.Application.Queries;
using Messenger.Application.Responses;
using Messenger.Domain.Repositories;

namespace Messenger.Application.Handlers;

public class GetChatsByUserIdQueryHandler(IChatRepository chatRepository, IMapper mapper) : IRequestHandler<GetChatsByUserIdQuery, List<ChatResponse>>
{
    private readonly IChatRepository _chatRepository = chatRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<ChatResponse>> Handle(GetChatsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var userChats = await _chatRepository.GetChatsByUserId(request.UserId);
        return _mapper.Map<List<ChatResponse>>(userChats);
    }
}
