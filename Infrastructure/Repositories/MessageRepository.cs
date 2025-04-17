using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.SeedWork;
using Infrastructure.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MessageRepository(IChatDbContext context) : IMessageRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async Task AddAsync(MessageEntity entity, CancellationToken cancellationToken)
    => await context.Messages.AddAsync(entity, cancellationToken);

    public async Task<IEnumerable<MessageEntity>> GetMessagesByGroupChatAsync(Guid groupChatId, CancellationToken cancellationToken)
        => await context.Messages
            .AsNoTracking()
            .Where(m => m.GroupChatId == groupChatId)
            .OrderBy(m => m.SentAt)
            .ToListAsync(cancellationToken);

    public async Task<IEnumerable<MessageEntity>> GetMessagesBetweenUsersAsync(Guid userA, Guid userB, CancellationToken cancellationToken)
        => await context.Messages
            .AsNoTracking()
            .Where(m =>
                m.ReceiverId.HasValue &&
                ((m.SenderId == userA && m.ReceiverId == userB) ||
                 (m.SenderId == userB && m.ReceiverId == userA)))
            .OrderBy(m => m.SentAt)
            .ToListAsync(cancellationToken);
}