using System.Dynamic;
using Messenger.Domain.Common;
using Messenger.Domain.Enums;

namespace Messenger.Domain.Entities;

public class Message : GuidEntity
{
    public Guid SenderId { get; set; }
    public Guid ChatId { get; set; }
    public required Chat Chat { get; set; }
    public required string Content { get; set; }
    public required DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public required MessageStatus Status { get; set; } = MessageStatus.Sent;
    public DateTime? ReadDateTime { get; set; }
}
