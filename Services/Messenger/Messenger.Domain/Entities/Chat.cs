using Messenger.Domain.Common;

namespace Messenger.Domain.Entities;

public class Chat : CreatedByEntity
{
    public string? Name { get; set; }
    public virtual required ICollection<ChatUser> ChatUsers { get; set; }
    public virtual ICollection<Message>? Messages { get; set; }
}
