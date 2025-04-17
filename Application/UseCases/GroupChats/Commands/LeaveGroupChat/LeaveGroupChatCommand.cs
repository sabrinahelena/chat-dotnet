using MediatR;

namespace Application.UseCases.GroupChats.Commands.LeaveGroupChat;

public record LeaveGroupChatCommand(Guid RoomId, Guid UserId)
    : IRequest<LeaveGroupChatResponse>;
