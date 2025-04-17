using MediatR;

namespace Application.UseCases.GroupChats.Commands.RemoveUserFromGroupChat;

/// <summary>
/// Command to remove a user from an existing group chat.
/// This command is used to request the removal of a user from a group chat room
/// by specifying the room ID and user ID. It will trigger the <see cref="RemoveUserFromGroupChatHandler"/> to handle the process.
/// </summary>
public record RemoveUserFromGroupChatCommand : IRequest<RemoveUserFromGroupChatResponse>
{
    /// <summary>
    /// The unique identifier of the group chat room from which the user is to be removed.
    /// </summary>
    public Guid RoomId { get; init; }

    /// <summary>
    /// The unique identifier of the user who is to be removed from the group chat.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveUserFromGroupChatCommand"/> class.
    /// </summary>
    /// <param name="RoomId">The unique identifier of the group chat room.</param>
    /// <param name="UserId">The unique identifier of the user to be removed from the room.</param>
    public RemoveUserFromGroupChatCommand(Guid RoomId, Guid UserId)
    {
        this.RoomId = RoomId;
        this.UserId = UserId;
    }
}