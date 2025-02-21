using System;

namespace Messenger.Application.Responses;

public class ChatResponse
{
    public string? Name { get; set; }
    public Guid UserId { get; set; }
    public List<MessageResponse>? Messages { get; set; }
}
