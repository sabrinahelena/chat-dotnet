using Application.UseCases.Messages.Queries.DTOs;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Messages.Queries.ReceiveMessagesFromGroupChat;

/// <summary>
/// Handler for receiving messages from a specific group chat.
/// This handler processes the <see cref="ReceiveMessagesFromGroupChatQuery"/> and interacts with the repository
/// to retrieve the messages associated with the specified group chat room.
/// </summary>
public class ReceiveMessagesFromGroupChatHandler(IMessageRepository repository) : IRequestHandler<ReceiveMessagesFromGroupChatQuery, ReceiveMessagesFromGroupChatResponse>
{
    /// <summary>
    /// Handles the process of retrieving all messages from a specific group chat room.
    /// It fetches the messages from the repository and maps them to a collection of <see cref="MessageDto"/>.
    /// </summary>
    /// <param name="query">The query containing the RoomId for the group chat to fetch messages from.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A <see cref="ReceiveMessagesFromGroupChatResponse"/> containing a list of messages in the form of <see cref="MessageDto"/>.</returns>
    public async Task<ReceiveMessagesFromGroupChatResponse> Handle(
        ReceiveMessagesFromGroupChatQuery query,
        CancellationToken cancellationToken)
    {
        var msgs = await repository.GetMessagesByGroupChatAsync(query.RoomId, cancellationToken);
        return new ReceiveMessagesFromGroupChatResponse(msgs.Select(m =>
            new MessageDto(m.Id.GetValueOrDefault(), m.SenderId, m.Content, m.SentAt)));
    }
}