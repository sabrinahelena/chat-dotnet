using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.GroupChats.Commands.RemoveUserFromGroupChat;

public class RemoveUserFromGroupChatHandler(IGroupChatRepository groupChatRepository,
    IUserRepository userRepository) : IRequestHandler<RemoveUserFromGroupChatCommand, RemoveUserFromGroupChatResponse>
{
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