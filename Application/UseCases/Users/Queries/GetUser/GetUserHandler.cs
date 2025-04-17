using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Users.Queries.GetUser;

/// <summary>
/// Handler for retrieving a user's details.
/// This handler processes the <see cref="GetUserQuery"/> and interacts with the repository
/// to fetch the user's information based on their user ID.
/// </summary>
public class GetUserHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, GetUserResponse>
{
    /// <summary>
    /// Handles the process of retrieving a user's details.
    /// It fetches the user's information from the repository based on the user ID.
    /// </summary>
    /// <param name="query">The query containing the UserId of the user whose details are being requested.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A <see cref="GetUserResponse"/> containing the user's ID, name, and login.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if no user is found with the provided UserId.</exception>
    public async Task<GetUserResponse> Handle(
        GetUserQuery query,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(query.UserId, cancellationToken)
            ?? throw new KeyNotFoundException("Usuário não foi encontrado.");

        return new GetUserResponse(user.Id.GetValueOrDefault(), user.Name, user.Login);
    }
}