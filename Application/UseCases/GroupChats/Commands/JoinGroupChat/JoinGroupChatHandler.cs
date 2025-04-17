using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.GroupChats.Commands.JoinGroupChat;

public class JoinGroupChatHandler(IGroupChatRepository groupChatRepository,
    IUserRepository userRepository) : IRequestHandler<JoinGroupChatCommand, JoinGroupChatResponse>
{

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