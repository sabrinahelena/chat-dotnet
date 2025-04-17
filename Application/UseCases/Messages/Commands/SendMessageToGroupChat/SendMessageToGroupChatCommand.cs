using MediatR;

namespace Application.UseCases.Messages.Commands.SendMessageToGroupChat;

/// <summary>
/// Command to send a message to a group chat.
/// This command is used to request sending a message to a specific group chat room
/// by specifying the sender's ID, the room ID, and the content of the message.
/// It triggers the <see cref="SendMessageToGroupChatHandler"/> to handle the message sending process.
/// </summary>
public record SendMessageToGroupChatCommand : IRequest<SendMessageToGroupChatResponse>
{
    /// <summary>
    /// The unique identifier of the sender of the message.
    /// </summary>
    public Guid SenderId { get; init; }

    /// <summary>
    /// The unique identifier of the group chat room where the message is being sent.
    /// </summary>
    public Guid RoomId { get; init; }

    /// <summary>
    /// The content (text) of the message to be sent to the group chat.
    /// </summary>
    public string Content { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SendMessageToGroupChatCommand"/> class.
    /// </summary>
    /// <param name="SenderId">The sender's unique identifier.</param>
    /// <param name="RoomId">The group chat room's unique identifier.</param>
    /// <param name="Content">The content of the message to be sent.</param>
    public SendMessageToGroupChatCommand(Guid SenderId, Guid RoomId, string Content)
    {
        this.SenderId = SenderId;
        this.RoomId = RoomId;
        this.Content = Content;
    }
}
