using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.GroupChats.Commands.CreateGroupChat;

/// <summary>
/// Handler for creating a new group chat.
/// This handler processes the <see cref="CreateGroupChatCommand"/> and interacts with the repository 
/// to add the new group chat room to the database.
/// </summary>
public class CreateGroupChatHandler(IGroupChatRepository repository) : IRequestHandler<CreateGroupChatCommand, CreateGroupChatResponse>
{
    /// <summary>
    /// Handles the creation of a new group chat room.
    /// Adds the new group chat room to the repository and commits the changes.
    /// </summary>
    /// <param name="command">The command containing the necessary data to create the group chat.</param>
    /// <param name="ct">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A <see cref="CreateGroupChatResponse"/> containing the ID and creation time of the newly created group chat.</returns>
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