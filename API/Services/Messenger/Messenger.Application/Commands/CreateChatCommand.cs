using MediatR;

namespace Messenger.Application.Commands;

public class CreateChatCommand : IRequest<Guid>
{
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? Name { get; set; }
    public required List<Guid> UserIds { get; set; }
}
