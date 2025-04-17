using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.GroupChats.Commands.LeaveGroupChat;

/// <summary>
/// Handler for leaving an existing group chat.
/// This handler processes the <see cref="LeaveGroupChatCommand"/> and interacts with the repositories
/// to remove a user from a group chat room if they are a member.
/// </summary>
public class LeaveGroupChatHandler(IGroupChatRepository groupChatRepository,
    IUserRepository userRepository) : IRequestHandler<LeaveGroupChatCommand, LeaveGroupChatResponse>
{

    /// <summary>
    /// Handles the process of removing a user from a group chat room.
    /// If the user is a member of the room, they are removed, and the changes are saved.
    /// </summary>
    /// <param name="cmd">The command containing the RoomId and UserId of the user who wants to leave the group chat.</param>
    /// <param name="ct">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A <see cref="LeaveGroupChatResponse"/> indicating whether the user was successfully removed from the group chat.</returns>
    public async Task<LeaveGroupChatResponse> Handle(
        LeaveGroupChatCommand cmd, CancellationToken ct)
    {
        var room = await groupChatRepository.GetByIdAsync(cmd.RoomId, ct);
        var user = await userRepository.GetByIdAsync(cmd.UserId, ct);
        if (room is null || user is null)
            return new LeaveGroupChatResponse(false);

        room.Members!.Remove(user);
        await groupChatRepository.UnitOfWork.CommitAsync(ct);
        return new LeaveGroupChatResponse(true);
    }
}