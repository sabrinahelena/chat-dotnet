using Application.UseCases.GroupChats.Dtos;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.GroupChats.Queries.GetGroupChats;

/// <summary>
/// Handler for retrieving a list of group chats.
/// This handler processes the <see cref="ListGroupChatsQuery"/> and interacts with the repository
/// to fetch all group chat rooms and returns them as a collection of <see cref="GroupChatDto"/> objects.
/// </summary>
public class GetGroupChatsHandler(IGroupChatRepository repository) : IRequestHandler<ListGroupChatsQuery, IEnumerable<GroupChatDto>>
{
    /// <summary>
    /// Handles the process of retrieving all group chat rooms.
    /// It fetches all rooms from the repository and maps them to a collection of <see cref="GroupChatDto"/>.
    /// </summary>
    /// <param name="query">The query containing parameters for listing the group chats.</param>
    /// <param name="ct">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A collection of <see cref="GroupChatDto"/> representing all group chat rooms.</returns>
    public async Task<IEnumerable<GroupChatDto>> Handle(
        ListGroupChatsQuery query, CancellationToken ct)
    {
        var rooms = await repository.GetAllAsync(ct);
        return rooms
            .Select(r => new GroupChatDto(r.Id.GetValueOrDefault(), r.CreatedAt, r.Members?.Count ?? 0));
    }
}