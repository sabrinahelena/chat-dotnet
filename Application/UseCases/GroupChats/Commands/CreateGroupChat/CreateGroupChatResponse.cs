namespace Application.UseCases.GroupChats.Commands.CreateGroupChat;

/// <summary>
/// Response returned after successfully creating a new group chat.
/// This response contains the ID of the newly created group chat room and 
/// the timestamp of when the room was created.
/// </summary>
public record CreateGroupChatResponse(Guid RoomId, DateTime CreatedAt);