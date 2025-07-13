using Messenger.Domain.Common;

namespace Messenger.Domain.Entities;

public class ChatUser : GuidEntity
{
    public Guid ChatId { get; set; } 
    public Chat? Chat { get; set; } 
    public required Guid UserId { get; set; }
}
