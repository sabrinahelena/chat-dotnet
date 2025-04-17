namespace Application.UseCases.Users.Queries.GetUser;

public record GetUserResponse(Guid Id, string Name, string Login);
