using Room.Domain.Common;

namespace Room.Domain.Entities;

public class RoomUser : GuidEntity
{
    public required string UserName { get; set; }
    public string Avatar { get; set; } = "https://i1.sndcdn.com/artworks-D1z0mq71bQhEyABg-cL8hUA-t500x500.jpg";
    public required UserStatus Status { get; set; }
}
