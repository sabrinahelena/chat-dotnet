using MediatR;

namespace Application.UseCases.Users.Commands.RegisterUser;

/// <summary>
/// Command to register a new user.
/// This command is used to request the creation of a new user by specifying their name, login, and password.
/// It triggers the <see cref="RegisterUserHandler"/> to process the registration request.
/// </summary>
public record RegisterUserCommand: IRequest<RegisterUserResponse>
{
    /// <summary>
    /// The name of the user to be registered.
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// The login (username) of the user to be registered.
    /// </summary>
    public string Login { get; init; } = string.Empty;

    /// <summary>
    /// The password of the user to be registered.
    /// </summary>
    public string Password { get; init; } = string.Empty;
}