using MediatR;

namespace Application.UseCases.GroupChats.Commands.JoinGroupChat;

/// <summary>
/// Command to join an existing group chat.
/// This command is used to request a user to join a group chat room by specifying
/// the room ID and user ID. It will trigger the <see cref="JoinGroupChatHandler"/> to handle the process.
/// </summary>
public record JoinGroupChatCommand : IRequest<JoinGroupChatResponse>
{
    /// <summary>
    /// The unique identifier of the group chat room the user wants to join.
    /// </summary>
    public Guid RoomId { get; init; }

    /// <summary>
    /// The unique identifier of the user attempting to join the group chat.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="JoinGroupChatCommand"/> class.
    /// </summary>
    /// <param name="RoomId">The unique identifier of the group chat room.</param>
    /// <param name="UserId">The unique identifier of the user trying to join the group chat.</param>
    public JoinGroupChatCommand(Guid RoomId, Guid UserId)
    {
        this.RoomId = RoomId;
        this.UserId = UserId;
    }
}
