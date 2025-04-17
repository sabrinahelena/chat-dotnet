using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Users.Commands.RegisterUser;

public sealed class RegisterUserHandler(IUserRepository repository): IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    public async Task<RegisterUserResponse> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var user = new UserEntity(command.Name, command.Login, command.Password);
        
        await repository.AddAsync(user, cancellationToken);

        await repository.UnitOfWork.CommitAsync(cancellationToken);

        return new RegisterUserResponse(true);
    }
}