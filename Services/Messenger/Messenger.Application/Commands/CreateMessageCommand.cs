using MediatR;
using Messenger.Domain.Enums;

namespace Messenger.Application.Commands;

public class CreateMessageCommand : IRequest<bool>
{
    public Guid ChatId { get; set; }
    public Guid SenderId { get; set; }
    public string? Content { get; set; }
    public DateTime Timestamp { get; set; }
    public MessageStatus Status { get; set; }
}
