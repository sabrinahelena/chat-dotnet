using MediatR;

namespace Application.UseCases.GroupChats.Commands.LeaveGroupChat;

/// <summary>
/// Command to leave an existing group chat.
/// This command is used to request a user to leave a group chat room by specifying
/// the room ID and user ID. It will trigger the <see cref="LeaveGroupChatHandler"/> to handle the process.
/// </summary>
public record LeaveGroupChatCommand : IRequest<LeaveGroupChatResponse>
{
    /// <summary>
    /// The unique identifier of the group chat room the user wants to leave.
    /// </summary>
    public Guid RoomId { get; init; }

    /// <summary>
    /// The unique identifier of the user who wants to leave the group chat.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LeaveGroupChatCommand"/> class.
    /// </summary>
    /// <param name="RoomId">The unique identifier of the group chat room.</param>
    /// <param name="UserId">The unique identifier of the user trying to leave the group chat.</param>
    public LeaveGroupChatCommand(Guid RoomId, Guid UserId)
    {
        this.RoomId = RoomId;
        this.UserId = UserId;
    }
}
