using Application.UseCases.Messages.Queries.DTOs;

namespace Application.UseCases.Messages.Queries.ReceiveMessagesFromGroupChat;

/// <summary>
/// Response returned after attempting to receive messages from a specific group chat.
/// This response contains the list of messages retrieved from the specified group chat room,
/// represented as a collection of <see cref="MessageDto"/>.
/// </summary>
public record ReceiveMessagesFromGroupChatResponse(IEnumerable<MessageDto> Messages);