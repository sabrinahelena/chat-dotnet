namespace Application.UseCases.Users.Queries.GetUser;

/// <summary>
/// Response returned after retrieving a user's details.
/// This response contains the user's ID, name, and login.
/// </summary>
public record GetUserResponse(Guid Id, string Name, string Login);