using Room.Domain.Common;
using Room.Domain.Enums;

namespace Room.Domain.Entities;

public class UserStatus : GuidEntity
{
    public State State { get; set;} = State.OFFLINE;
    public string LastChanged { get; set; } = DateTime.UtcNow.ToString();

}
