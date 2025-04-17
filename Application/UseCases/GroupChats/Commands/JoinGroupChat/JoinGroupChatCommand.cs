using MediatR;

namespace Application.UseCases.GroupChats.Commands.JoinGroupChat;

public record JoinGroupChatCommand(Guid RoomId, Guid UserId)
    : IRequest<JoinGroupChatResponse>;
