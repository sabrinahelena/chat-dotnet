using MediatR;

namespace Application.UseCases.GroupChats.Commands.DeleteGroupChat;

/// <summary>
/// Command to delete an existing group chat.
/// This command is used to request the deletion of a group chat room by its ID.
/// It will trigger the <see cref="DeleteGroupChatHandler"/> to handle the deletion process.
/// </summary>
public record DeleteGroupChatCommand : IRequest<DeleteGroupChatResponse>
{
    /// <summary>
    /// The unique identifier of the group chat room to be deleted.
    /// </summary>
    public Guid RoomId { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteGroupChatCommand"/> class.
    /// </summary>
    /// <param name="RoomId">The unique identifier of the group chat room to be deleted.</param>
    public DeleteGroupChatCommand(Guid RoomId)
    {
        this.RoomId = RoomId;
    }
}