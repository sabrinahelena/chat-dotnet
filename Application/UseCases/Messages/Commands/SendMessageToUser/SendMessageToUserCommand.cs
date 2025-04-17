using MediatR;
using System.Text.Json.Serialization;

namespace Application.UseCases.Messages.Commands.SendMessageToUser;

/// <summary>
/// Command to send a direct message to a user.
/// This command is used to request sending a message to a specific user by specifying
/// the sender's ID, the receiver's ID, and the content of the message.
/// It triggers the <see cref="SendMessageToUserHandler"/> to handle the message sending process.
/// </summary>
public record SendMessageToUserCommand : IRequest<SendMessageToUserResponse>
{
    /// <summary>
    /// The unique identifier of the sender of the message.
    /// </summary>
    public Guid SenderId { get; init; }

    /// <summary>
    /// The unique identifier of the receiver of the message.
    /// </summary>
    [JsonIgnore]
    public Guid ReceiverId { get; init; }

    /// <summary>
    /// The content (text) of the message to be sent to the user.
    /// </summary>
    public string Content { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SendMessageToUserCommand"/> class.
    /// </summary>
    /// <param name="SenderId">The sender's unique identifier.</param>
    /// <param name="ReceiverId">The receiver's unique identifier.</param>
    /// <param name="Content">The content of the message to be sent.</param>
    public SendMessageToUserCommand(Guid SenderId, Guid ReceiverId, string Content)
    {
        this.SenderId = SenderId;
        this.ReceiverId = ReceiverId;
        this.Content = Content;
    }
}
