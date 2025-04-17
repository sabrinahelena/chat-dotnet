using Domain.Entities;
using Domain.SeedWork;

namespace Domain.Interfaces.Repositories;

/// <summary>
/// Repository interface for managing group chat entities.
/// This interface provides methods for adding, removing, updating, and retrieving group chats.
/// </summary>
public interface IGroupChatRepository: IRepository
{
    /// <summary>
    /// Asynchronously adds a new group chat to the repository.
    /// </summary>
    /// <param name="groupChat">The group chat entity to be added.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(GroupChatEntity groupChat, CancellationToken cancellationToken);

    /// <summary>
    /// Removes a group chat from the repository.
    /// </summary>
    /// <param name="groupChat">The group chat entity to be removed.</param>
    void Remove(GroupChatEntity groupChat);

    /// <summary>
    /// Asynchronously retrieves a group chat by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the group chat.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A task representing the asynchronous operation, containing the found group chat or null if not found.</returns>
    Task<GroupChatEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves all group chats from the repository.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A task representing the asynchronous operation, containing an enumeration of all group chats.</returns>
    Task<IEnumerable<GroupChatEntity>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing group chat in the repository.
    /// </summary>
    /// <param name="groupChatEntity">The group chat entity to be updated.</param>
    void Update(GroupChatEntity groupChatEntity);
}