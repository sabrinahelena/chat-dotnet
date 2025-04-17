using Application.UseCases.Messages.Queries.DTOs;

namespace Application.UseCases.Messages.Queries.ReceiveMessagesFromGroupChat;
public record ReceiveMessagesFromGroupChatResponse(IEnumerable<MessageDto> Messages);