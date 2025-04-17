using MediatR;

namespace Application.UseCases.Messages.Commands.SendMessageToGroupChat;

public record SendMessageToGroupChatCommand(Guid SenderId, Guid RoomId, string Content)
    : IRequest<SendMessageToGroupChatResponse>;
