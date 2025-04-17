namespace Application.UseCases.Messages.Commands.SendMessageToUser;

/// <summary>
/// Response returned after attempting to send a direct message to a user.
/// This response indicates whether the operation to send the message was successful
/// and includes the ID of the sent message if successful.
/// </summary>
public record SendMessageToUserResponse(bool Success, Guid? MessageId = null);