namespace Application.UseCases.GroupChats.Commands.RemoveUserFromGroupChat;

/// <summary>
/// Response returned after attempting to remove a user from a group chat.
/// This response indicates whether the operation to remove the user from the group chat was successful.
/// </summary>
public record RemoveUserFromGroupChatResponse(bool Success);