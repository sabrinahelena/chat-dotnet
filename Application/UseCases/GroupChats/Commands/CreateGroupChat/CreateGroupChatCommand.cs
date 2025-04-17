using MediatR;

namespace Application.UseCases.GroupChats.Commands.CreateGroupChat;

/// <summary>
/// Command to create a new group chat.
/// This command is used to request the creation of a new group chat room.
/// It contains the necessary data required for creating the group chat, 
/// and will trigger the <see cref="CreateGroupChatHandler"/> to handle the creation process.
/// </summary>
public record CreateGroupChatCommand() : IRequest<CreateGroupChatResponse>;