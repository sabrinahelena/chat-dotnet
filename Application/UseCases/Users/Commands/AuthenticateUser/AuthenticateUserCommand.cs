using MediatR;

namespace Application.UseCases.Users.Commands.AuthenticateUser;

/// <summary>
/// Command to authenticate a user.
/// This command is used to request the authentication of a user by specifying their login and password.
/// It triggers the <see cref="AuthenticateUserHandler"/> to process the authentication request.
/// </summary>
public class AuthenticateUserCommand : IRequest<AuthenticateUserResponse>
{
    /// <summary>
    /// The login of the user trying to authenticate.
    /// </summary>
    public string Login { get; init; } = string.Empty;

    /// <summary>
    /// The password of the user trying to authenticate.
    /// </summary>
    public string Password { get; init; } = string.Empty;
}