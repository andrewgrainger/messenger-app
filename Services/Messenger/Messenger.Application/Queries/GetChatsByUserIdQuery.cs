using MediatR;
using Messenger.Application.Responses;

namespace Messenger.Application.Queries;

public class GetChatsByUserIdQuery(Guid userId) : IRequest<List<ChatResponse>>
{
    public Guid UserId { get; set; } = userId;
}   
