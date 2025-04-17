using Domain.Entities;
using Domain.SeedWork;

namespace Domain.Interfaces.Repositories;

/// <summary>
/// Repository interface for managing user entities.
/// This interface provides methods for adding, retrieving users by their ID, and retrieving users by their login.
/// </summary>
public interface IUserRepository : IRepository
{
    /// <summary>
    /// Asynchronously adds a new user to the repository.
    /// </summary>
    /// <param name="entity">The user entity to be added.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(UserEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A task representing the asynchronous operation, containing the found user or null if not found.</returns>
    Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves a user by their login.
    /// </summary>
    /// <param name="login">The login (username) of the user.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A task representing the asynchronous operation, containing the found user or null if not found.</returns>
    Task<UserEntity?> GetByLoginAsync(string login, CancellationToken cancellationToken);
}