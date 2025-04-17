namespace Application.UseCases.Users.Commands.AuthenticateUser;

/// <summary>
/// Response returned after attempting to authenticate a user.
/// This response indicates whether the authentication was successful and includes the user's ID if successful.
/// </summary>
public record AuthenticateUserResponse(bool Success, Guid? UserId = null);