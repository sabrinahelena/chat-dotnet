using MediatR;

namespace Application.UseCases.GroupChats.Commands.DeleteGroupChat;

public record DeleteGroupChatCommand(Guid RoomId) : IRequest<DeleteGroupChatResponse>;