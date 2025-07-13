using AutoMapper;
using MediatR;
using Messenger.Application.Commands;
using Messenger.Application.Exceptions;
using Messenger.Domain.Entities;
using Messenger.Domain.Repositories;

namespace Messenger.Application.Handlers;

public class CreateMessageCommandHandler(IChatRepository chatRepository, IMapper mapper) : IRequestHandler<CreateMessageCommand, bool>
{
    private readonly IChatRepository _chatRepository = chatRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        var newMessage = _mapper.Map<Message>(request);
        return await _chatRepository.CreateMessage(newMessage);
    }
}
