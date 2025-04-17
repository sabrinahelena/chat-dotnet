using MediatR;

namespace Application.UseCases.Users.Commands.RegisterUser;

public record RegisterUserCommand: IRequest<RegisterUserResponse>
{
    public string Name { get; init; } = string.Empty;
    public string Login { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}