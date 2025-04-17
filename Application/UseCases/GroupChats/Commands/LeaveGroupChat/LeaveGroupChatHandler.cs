using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.GroupChats.Commands.LeaveGroupChat;

public class LeaveGroupChatHandler(IGroupChatRepository groupChatRepository,
    IUserRepository userRepository) : IRequestHandler<LeaveGroupChatCommand, LeaveGroupChatResponse>
{

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