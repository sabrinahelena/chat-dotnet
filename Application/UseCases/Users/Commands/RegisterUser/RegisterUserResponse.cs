namespace Application.UseCases.Users.Commands.RegisterUser;

/// <summary>
/// Response returned after attempting to register a new user.
/// This response indicates whether the registration operation was successful.
/// </summary>
public record RegisterUserResponse(bool Success);