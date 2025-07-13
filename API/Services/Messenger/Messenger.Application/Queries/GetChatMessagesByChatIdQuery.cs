using MediatR;
using Messenger.Application.Responses;
using Messenger.Domain.Pagination;

namespace Messenger.Application.Queries;

public record GetChatMessagesByChatIdQuery(Guid ChatId, int PageIndex, int PageSize) : IRequest<PaginatedList<MessageResponse>>;
