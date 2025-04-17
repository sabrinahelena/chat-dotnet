using Domain.Entities;
using Domain.SeedWork;

namespace Domain.Interfaces.Repositories;

/// <summary>
/// Repository interface for managing message entities.
/// This interface provides methods for adding, retrieving messages by group chat, 
/// and retrieving messages exchanged between two users.
/// </summary>
public interface IMessageRepository : IRepository
{
    /// <summary>
    /// Asynchronously adds a new message to the repository.
    /// </summary>
    /// <param name="message">The message entity to be added.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(MessageEntity message, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves all messages from a specific group chat.
    /// </summary>
    /// <param name="groupChatId">The unique identifier of the group chat.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A task representing the asynchronous operation, containing an enumeration of messages in the group chat.</returns>
    Task<IEnumerable<MessageEntity>> GetMessagesByGroupChatAsync(Guid groupChatId, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves all messages exchanged between two specific users.
    /// </summary>
    /// <param name="userA">The unique identifier of the first user.</param>
    /// <param name="userB">The unique identifier of the second user.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A task representing the asynchronous operation, containing an enumeration of messages exchanged between the two users.</returns>
    Task<IEnumerable<MessageEntity>> GetMessagesBetweenUsersAsync(Guid userA, Guid userB, CancellationToken cancellationToken);
}