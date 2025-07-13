using System;
using System.Text.Json.Serialization;

namespace Room.Application.Responses;

public class RoomUserResponse
{
    [JsonPropertyName("_id")]
    public required string Id {get; set; }
    [JsonPropertyName("username")]
    public required string UserName { get; set; }
    public required string Avatar { get; set; }
    public required UserStatusResponse Status { get; set; }
}
