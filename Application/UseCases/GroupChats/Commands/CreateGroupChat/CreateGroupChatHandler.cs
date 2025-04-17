using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.GroupChats.Commands.CreateGroupChat;

public class CreateGroupChatHandler(IGroupChatRepository repository) : IRequestHandler<CreateGroupChatCommand, CreateGroupChatResponse>
{
    public async Task<CreateGroupChatResponse> Handle(
        CreateGroupChatCommand command, CancellationToken ct)
    {
        var room = new GroupChatEntity
        {
            CreatedAt = DateTime.UtcNow
        };
        await repository.AddAsync(room, ct);
        await repository.UnitOfWork.CommitAsync(ct);
        return new CreateGroupChatResponse(room.Id.GetValueOrDefault(), room.CreatedAt);
    }
}