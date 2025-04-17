using MediatR;

namespace Application.UseCases.Users.Queries.GetUser;

public record GetUserQuery(Guid UserId) : IRequest<GetUserResponse>;
