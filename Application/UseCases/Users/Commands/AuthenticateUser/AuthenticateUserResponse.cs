namespace Application.UseCases.Users.Commands.AuthenticateUser;

public record AuthenticateUserResponse(bool Success, Guid? UserId = null);