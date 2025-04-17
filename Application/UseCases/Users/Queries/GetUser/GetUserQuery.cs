using MediatR;

namespace Application.UseCases.Users.Queries.GetUser;

/// <summary>
/// Query to retrieve a user's details.
/// This query is used to request the details of a specific user by specifying their user ID.
/// It triggers the <see cref="GetUserHandler"/> to process and return the result.
/// </summary>
public record GetUserQuery(Guid UserId) : IRequest<GetUserResponse>;