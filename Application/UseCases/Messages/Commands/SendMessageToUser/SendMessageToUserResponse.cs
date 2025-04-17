namespace Application.UseCases.Messages.Commands.SendMessageToUser;

public record SendMessageToUserResponse(bool Success, Guid? MessageId = null);