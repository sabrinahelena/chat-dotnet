namespace Application.UseCases.Messages.Commands.SendMessageToGroupChat;

/// <summary>
/// Response returned after attempting to send a message to a group chat.
/// This response indicates whether the operation to send the message was successful
/// and includes the ID of the sent message if successful.
/// </summary>
public record SendMessageToGroupChatResponse(bool Success, Guid? MessageId = null);