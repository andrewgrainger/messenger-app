using Messenger.Domain.Entities;
using Messenger.Domain.Pagination;

namespace Messenger.Domain.Repositories;

public interface IChatRepository : IAsyncRepository<Chat>
{
    Task<IEnumerable<Chat>> GetChatsByUserId(Guid userId);
    Task<bool> CreateMessage(Message message);
    Task<PaginatedList<Message>> GetMessagesByChatId(Guid chatId, int pageIndex, int pageSize);
}
