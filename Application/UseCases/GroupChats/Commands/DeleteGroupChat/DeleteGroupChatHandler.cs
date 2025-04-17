using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.GroupChats.Commands.DeleteGroupChat;

/// <summary>
/// Handler for deleting an existing group chat.
/// This handler processes the <see cref="DeleteGroupChatCommand"/> and interacts with the repository
/// to remove the group chat room from the database.
/// </summary>
public class DeleteGroupChatHandler(IGroupChatRepository repository) : IRequestHandler<DeleteGroupChatCommand, DeleteGroupChatResponse>
{

    /// <summary>
    /// Handles the deletion of an existing group chat room.
    /// Removes the group chat room from the repository and commits the changes.
    /// </summary>
    /// <param name="cmd">The command containing the ID of the group chat room to be deleted.</param>
    /// <param name="ct">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A <see cref="DeleteGroupChatResponse"/> indicating whether the deletion was successful.</returns>
    public async Task<DeleteGroupChatResponse> Handle(
        DeleteGroupChatCommand cmd, CancellationToken ct)
    {
        var room = await repository.GetByIdAsync(cmd.RoomId, ct);
        if (room is null) return new DeleteGroupChatResponse(false);

        repository.Remove(room);
        await repository.UnitOfWork.CommitAsync(ct);
        return new DeleteGroupChatResponse(true);
    }
}