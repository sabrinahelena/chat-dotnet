using Application.UseCases.GroupChats.Dtos;
using MediatR;

namespace Application.UseCases.GroupChats.Queries.GetGroupChats;

public record ListGroupChatsQuery() : IRequest<IEnumerable<GroupChatDto>>;

