using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Users.Commands.AuthenticateUser;

public sealed class AuthenticateUserHandler(IUserRepository userRepository)
    : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResponse>
{

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