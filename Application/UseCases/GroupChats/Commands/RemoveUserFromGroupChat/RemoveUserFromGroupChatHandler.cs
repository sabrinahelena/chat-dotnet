using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.GroupChats.Commands.RemoveUserFromGroupChat;

/// <summary>
/// Handler for removing a user from an existing group chat.
/// This handler processes the <see cref="RemoveUserFromGroupChatCommand"/> and interacts with the repositories
/// to remove a user from a group chat room if they are a member.
/// </summary>
public class RemoveUserFromGroupChatHandler(IGroupChatRepository groupChatRepository,
    IUserRepository userRepository) : IRequestHandler<RemoveUserFromGroupChatCommand, RemoveUserFromGroupChatResponse>
{

    /// <summary>
    /// Handles the process of removing a user from a group chat room.
    /// If the user is a member of the room, they are removed, and the changes are saved.
    /// </summary>
    /// <param name="cmd">The command containing the RoomId and UserId of the user to be removed from the group chat.</param>
    /// <param name="ct">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A <see cref="RemoveUserFromGroupChatResponse"/> indicating whether the user was successfully removed from the group chat.</returns>
    public async Task<RemoveUserFromGroupChatResponse> Handle(
        RemoveUserFromGroupChatCommand cmd, CancellationToken ct)
    {
        var room = await groupChatRepository.GetByIdAsync(cmd.RoomId, ct);
        var user = await userRepository.GetByIdAsync(cmd.UserId, ct);
        if (room is null || user is null)
            return new RemoveUserFromGroupChatResponse(false);

        room.Members!.Remove(user);
        await groupChatRepository.UnitOfWork.CommitAsync(ct);
        return new RemoveUserFromGroupChatResponse(true);
    }
}