using Domain.Entities;
using Domain.SeedWork;

namespace Domain.Interfaces.Repositories;

public interface IGroupChatRepository: IRepository
{
    Task AddAsync(GroupChatEntity groupChat, CancellationToken cancellationToken);
    void Remove(GroupChatEntity groupChat);
    Task<GroupChatEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<GroupChatEntity>> GetAllAsync(CancellationToken cancellationToken);
}