using MediatR;

namespace Application.UseCases.Messages.Queries.ReceiveMessagesFromGroupChat;

/// <summary>
/// Query to retrieve messages from a specific group chat.
/// This query is used to request the list of messages for a given group chat room by specifying the room ID.
/// It triggers the <see cref="ReceiveMessagesFromGroupChatHandler"/> to process and return the result.
/// </summary>
public record ReceiveMessagesFromGroupChatQuery(Guid RoomId)
    : IRequest<ReceiveMessagesFromGroupChatResponse>;