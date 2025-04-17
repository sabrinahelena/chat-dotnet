using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Messages.Commands.SendMessageToGroupChat;

/// <summary>
/// Handler for sending a message to a group chat.
/// This handler processes the <see cref="SendMessageToGroupChatCommand"/> and interacts with the repository
/// to store the message and commit the transaction.
/// </summary>
public class SendMessageToGroupChatHandler(IMessageRepository repository) : IRequestHandler<SendMessageToGroupChatCommand, SendMessageToGroupChatResponse>
{
    /// <summary>
    /// Handles the process of sending a message to a group chat room.
    /// It creates a new message entity and stores it in the repository.
    /// </summary>
    /// <param name="cmd">The command containing the sender's ID, room ID, and message content.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A <see cref="SendMessageToGroupChatResponse"/> indicating whether the message was successfully sent.</returns>
    public async Task<SendMessageToGroupChatResponse> Handle(
        SendMessageToGroupChatCommand cmd,
        CancellationToken cancellationToken)
    {
        var message = new MessageEntity
        {
            Content = cmd.Content,
            SentAt = DateTime.UtcNow,
            SenderId = cmd.SenderId,
            ReceiverId = null,
            GroupChatId = cmd.RoomId
        };

        await repository.AddAsync(message, cancellationToken);
        await repository.UnitOfWork.CommitAsync(cancellationToken);

        return new SendMessageToGroupChatResponse(true, message.Id);
    }
}