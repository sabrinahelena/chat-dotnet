using MediatR;

namespace Application.UseCases.GroupChats.Commands.RemoveUserFromGroupChat;

public record RemoveUserFromGroupChatCommand(Guid RoomId, Guid UserId)
    : IRequest<RemoveUserFromGroupChatResponse>;