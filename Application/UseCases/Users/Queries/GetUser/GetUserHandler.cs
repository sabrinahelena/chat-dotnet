using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Users.Queries.GetUser;

public class GetUserHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, GetUserResponse>
{
    public async Task<GetUserResponse> Handle(
        GetUserQuery query,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(query.UserId, cancellationToken)
            ?? throw new KeyNotFoundException("User was not found.");

        return new GetUserResponse(user.Id.GetValueOrDefault(), user.Name, user.Login);
    }
}