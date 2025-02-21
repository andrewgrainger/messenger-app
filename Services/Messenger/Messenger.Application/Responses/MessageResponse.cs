using Messenger.Domain.Enums;

namespace Messenger.Application.Responses;

public class MessageResponse
{
    public Guid SenderId { get; set; }
    public string? Content { get; set; }
    public DateTime Timestamp { get; set; }
    public MessageStatus Status { get; set; }
    public DateTime? ReadDateTime { get; set; }
}
