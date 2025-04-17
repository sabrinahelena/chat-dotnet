namespace Application.UseCases.Messages.Commands.SendMessageToGroupChat;

public record SendMessageToGroupChatResponse(bool Success, Guid? MessageId = null);
