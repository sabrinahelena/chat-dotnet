using Application.UseCases.GroupChats.Dtos;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.GroupChats.Queries.GetGroupChats
{
    public class GetGroupChatsHandler(IGroupChatRepository repository) : IRequestHandler<ListGroupChatsQuery, IEnumerable<GroupChatDto>>
    {
        public async Task<IEnumerable<GroupChatDto>> Handle(
            ListGroupChatsQuery query, CancellationToken ct)
        {
            var rooms = await repository.GetAllAsync(ct);
            return rooms
                .Select(r => new GroupChatDto(r.Id.GetValueOrDefault(), r.CreatedAt, r.Members?.Count ?? 0));
        }
    }
}