using Messenger.Domain.Entities;
using Messenger.Domain.Pagination;
using Messenger.Domain.Repositories;
using Messenger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Infrastructure.Repositories;

public class ChatRepository(ChatDbContext chatDbContext) : AsyncRepository<Chat>(chatDbContext), IChatRepository
{
    protected readonly ChatDbContext _chatDbContext = chatDbContext;

    public async Task<IEnumerable<Chat>> GetChatsByUserId(Guid userId)
    {
        return await _chatDbContext.Chats
            .Where(chat => chat.ChatUsers.Any(cu => cu.UserId == userId))
            .ToListAsync(); 
    }

    public async Task<bool> CreateMessage(Message message) {
        _chatDbContext.Messages.Add(message);
        return await _chatDbContext.SaveChangesAsync() > 0;
    }

    public async Task<PaginatedList<Message>> GetMessagesByChatId(Guid chatId, int pageIndex, int pageSize)
    {
        var chatMessageQuery = _chatDbContext.Messages
            .Where(x => x.ChatId == chatId)
            .AsQueryable();
        
        var totalMessages = await chatMessageQuery.CountAsync();

        var messages = await chatMessageQuery
            .OrderByDescending(x => x.Timestamp) 
            .Skip((pageIndex - 1 ) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Message>(
                pageIndex: pageIndex,
                pageSize: pageSize,
                totalCount: totalMessages,
                data: messages
        );
    }
}
