using Domain.Entities;
using Domain.SeedWork;

namespace Domain.Interfaces.Repositories;

public interface IMessageRepository: IRepository
{
    Task AddAsync(MessageEntity message, CancellationToken cancellationToken);
    Task<IEnumerable<MessageEntity>> GetMessagesByGroupChatAsync(Guid groupChatId, CancellationToken cancellationToken);
    Task<IEnumerable<MessageEntity>> GetMessagesBetweenUsersAsync(Guid userA, Guid userB, CancellationToken cancellationToken);
}