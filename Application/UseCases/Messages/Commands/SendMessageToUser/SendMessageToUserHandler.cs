using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Messages.Commands.SendMessageToUser;

/// <summary>
/// Handler for sending a direct message to a user.
/// This handler processes the <see cref="SendMessageToUserCommand"/> and interacts with the repository
/// to store the message and commit the transaction.
/// </summary>
public class SendMessageToUserHandler(IMessageRepository repository) : IRequestHandler<SendMessageToUserCommand, SendMessageToUserResponse>
{

    /// <summary>
    /// Handles the process of sending a message to a specific user.
    /// It creates a new message entity and stores it in the repository.
    /// </summary>
    /// <param name="cmd">The command containing the sender's ID, receiver's ID, and message content.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A <see cref="SendMessageToUserResponse"/> indicating whether the message was successfully sent.</returns>
    public async Task<SendMessageToUserResponse> Handle(
        SendMessageToUserCommand cmd,
        CancellationToken cancellationToken)
    {
        var message = new MessageEntity
        {
            Content = cmd.Content,
            SentAt = DateTime.UtcNow,
            SenderId = cmd.SenderId,
            ReceiverId = cmd.ReceiverId,
            GroupChatId = null
        };

        await repository.AddAsync(message, cancellationToken);
        await repository.UnitOfWork.CommitAsync(cancellationToken);

        return new SendMessageToUserResponse(true, message.Id);
    }
}