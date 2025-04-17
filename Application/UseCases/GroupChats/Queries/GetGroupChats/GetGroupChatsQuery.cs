using Application.UseCases.GroupChats.Dtos;
using MediatR;

namespace Application.UseCases.GroupChats.Queries.GetGroupChats;

/// <summary>
/// Query to retrieve a list of all group chats.
/// This query is used to request a list of all available group chat rooms from the system.
/// It triggers the <see cref="GetGroupChatsHandler"/> to process and return the result.
/// </summary>
public record ListGroupChatsQuery() : IRequest<IEnumerable<GroupChatDto>>;