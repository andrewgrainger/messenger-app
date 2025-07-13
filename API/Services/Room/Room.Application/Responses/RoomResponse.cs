using System;
using System.Text.Json.Serialization;

namespace Room.Application.Responses;

public class RoomResponse
{
    [JsonPropertyName("roomId")]
    public required string Id { get; set; }
    public required string RoomName { get; set; }
    public required string Avatar { get; set; }
    public required IReadOnlyList<RoomUserResponse> Users { get; set; }
    public int? UnreadCount { get; set; }
    public int? Index { get; set; }
    public LastMessageResponse? LastMessage { get; set; }
}
