using MediatR;

namespace Application.UseCases.GroupChats.Commands.CreateGroupChat;

public record CreateGroupChatCommand() : IRequest<CreateGroupChatResponse>;