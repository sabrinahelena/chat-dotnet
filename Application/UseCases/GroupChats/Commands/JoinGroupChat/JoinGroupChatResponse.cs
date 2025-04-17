namespace Application.UseCases.GroupChats.Commands.JoinGroupChat;

/// <summary>
/// Response returned after attempting to join a group chat.
/// This response indicates whether the operation to add the user to the group chat was successful.
/// </summary>
public record JoinGroupChatResponse(bool Success);