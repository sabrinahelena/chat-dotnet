using MediatR;

namespace Application.UseCases.Users.Commands.AuthenticateUser;

public class AuthenticateUserCommand : IRequest<AuthenticateUserResponse>
{
    public string Login { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
