using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Users.Commands.AuthenticateUser;

/// <summary>
/// Handler for authenticating a user.
/// This handler processes the <see cref="AuthenticateUserCommand"/> and interacts with the repository
/// to validate the user's credentials and authenticate them.
/// </summary>
public sealed class AuthenticateUserHandler(IUserRepository userRepository)
    : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResponse>
{

    /// <summary>
    /// Handles the process of authenticating a user.
    /// It checks if the provided login and password match an existing user in the repository.
    /// </summary>
    /// <param name="command">The command containing the login and password to authenticate the user.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>An <see cref="AuthenticateUserResponse"/> indicating whether authentication was successful.</returns>
    public async Task<AuthenticateUserResponse> Handle(
        AuthenticateUserCommand command,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByLoginAsync(command.Login, cancellationToken);

        if (user is null || user.Password != command.Password)
            return new AuthenticateUserResponse(false);

        return new AuthenticateUserResponse(true, user.Id);
    }
}