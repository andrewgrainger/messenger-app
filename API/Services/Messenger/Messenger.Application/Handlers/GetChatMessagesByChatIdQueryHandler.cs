using AutoMapper;
using MediatR;
using Messenger.Application.Queries;
using Messenger.Application.Responses;
using Messenger.Domain.Pagination;
using Messenger.Domain.Repositories;

namespace Messenger.Application.Handlers;

internal sealed class GetChatMessagesByChatIdQueryHandler(IChatRepository chatRepository, IMapper mapper) : IRequestHandler<GetChatMessagesByChatIdQuery, PaginatedList<MessageResponse>>
{
    private readonly IChatRepository _chatRepository = chatRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<MessageResponse>> Handle(GetChatMessagesByChatIdQuery request, CancellationToken cancellationToken)
    {
        var chatMessages = await _chatRepository.GetMessagesByChatId(request.ChatId, request.PageIndex, request.PageSize);
        return _mapper.Map<PaginatedList<MessageResponse>>(chatMessages);
    }
}
