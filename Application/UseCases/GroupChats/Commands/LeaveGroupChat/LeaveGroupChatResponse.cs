namespace Application.UseCases.GroupChats.Commands.LeaveGroupChat;

/// <summary>
/// Response returned after attempting to leave a group chat.
/// This response indicates whether the operation to remove the user from the group chat was successful.
/// </summary>
public record LeaveGroupChatResponse(bool Success);