using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.GroupChats.Commands.DeleteGroupChat;

public class DeleteGroupChatHandler(IGroupChatRepository repository) : IRequestHandler<DeleteGroupChatCommand, DeleteGroupChatResponse>
{
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