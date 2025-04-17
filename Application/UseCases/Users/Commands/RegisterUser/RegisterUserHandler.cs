using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Users.Commands.RegisterUser;

/// <summary>
/// Handler for registering a new user.
/// This handler processes the <see cref="RegisterUserCommand"/> and interacts with the repository
/// to create a new user and save the user information to the database.
/// </summary>
public sealed class RegisterUserHandler(IUserRepository repository): IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{

    /// <summary>
    /// Handles the user registration process.
    /// It creates a new user entity, adds it to the repository, and commits the transaction.
    /// </summary>
    /// <param name="command">The command containing the user's details to be registered.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A <see cref="RegisterUserResponse"/> indicating whether the user was successfully registered.</returns>
    public async Task<RegisterUserResponse> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var user = new UserEntity(command.Name, command.Login, command.Password);
        
        await repository.AddAsync(user, cancellationToken);

        await repository.UnitOfWork.CommitAsync(cancellationToken);

        return new RegisterUserResponse(true);
    }
}