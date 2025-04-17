using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.GroupChats.Commands.JoinGroupChat;

/// <summary>
/// Handler for joining an existing group chat.
/// This handler processes the <see cref="JoinGroupChatCommand"/> and interacts with the repositories
/// to add a user to a group chat room if they are not already a member.
/// </summary>
public class JoinGroupChatHandler(IGroupChatRepository groupChatRepository,
    IUserRepository userRepository) : IRequestHandler<JoinGroupChatCommand, JoinGroupChatResponse>
{

    /// <summary>
    /// Handles the process of adding a user to a group chat room.
    /// If the user is not already a member, they are added to the room, and the changes are saved.
    /// </summary>
    /// <param name="cmd">The command containing the RoomId and UserId of the user who wants to join the group chat.</param>
    /// <param name="ct">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A <see cref="JoinGroupChatResponse"/> indicating whether the user was successfully added to the group chat.</returns>
    public async Task<JoinGroupChatResponse> Handle(
        JoinGroupChatCommand cmd, CancellationToken ct)
    {
        var room = await groupChatRepository.GetByIdAsync(cmd.RoomId, ct);
        var user = await userRepository.GetByIdAsync(cmd.UserId, ct);
        if (room is null || user is null)
            return new JoinGroupChatResponse(false);

        if (room.Members!.Any(m => m.Id == cmd.UserId) == false)
            room.Members!.Add(user);

        groupChatRepository.Update(room);

        await groupChatRepository.UnitOfWork.CommitAsync(ct);
        return new JoinGroupChatResponse(true);
    }
}