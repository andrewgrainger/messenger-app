using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Messenger.Application.Commands;
using Messenger.Domain.Repositories;
using Messenger.Domain.Entities;

namespace Messenger.Application.Handlers;

public class CreateChatCommandHandler(IChatRepository chatRepository, IMapper mapper) : IRequestHandler<CreateChatCommand, Guid>
{
    private readonly IChatRepository _chatRepository = chatRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Guid> Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        var newChat = _mapper.Map<Chat>(request);
        var addedChat = await _chatRepository.AddAsync(newChat);
        return addedChat.Id;
    }
}
