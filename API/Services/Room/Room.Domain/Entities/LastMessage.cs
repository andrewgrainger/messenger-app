using Room.Domain.Common;

namespace Room.Domain.Entities;

public class LastMessage : GuidEntity
{
    public required string Content { get; set; }
    public required string SenderId { get; set; }
    public string? Username { get; set; }
    public string? Timestamp { get; set; }
    public bool? IsSaved { get; set; }
    public bool? IsDistributed { get; set; }
    public bool? IsSeen { get; set; } 
    public bool? IsNew { get; set; }
    public List<MessageFile>? Files { get; set; } 
}
