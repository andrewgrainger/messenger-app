using Room.Domain.Common;

namespace Room.Domain.Entities;

public class Rooms : GuidEntity
{
    public required string RoomName { get; set; }
    public string Avatar { get; set; } = "https://i1.sndcdn.com/artworks-D1z0mq71bQhEyABg-cL8hUA-t500x500.jpg";
    public virtual List<RoomUser>? Users { get; set; }
    public int? UnreadCount { get; set; }
    public int? Index { get; set; }
    public LastMessage? LastMessage { get; set; }
}
