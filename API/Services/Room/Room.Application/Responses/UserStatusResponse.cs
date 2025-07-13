using System;

namespace Room.Application.Responses;

public class UserStatusResponse
{
    public required string State { get; set;}
    public required string LastChanged { get; set; }
}
