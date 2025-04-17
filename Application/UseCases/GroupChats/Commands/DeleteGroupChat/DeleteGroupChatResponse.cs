namespace Application.UseCases.GroupChats.Commands.DeleteGroupChat;

/// <summary>
/// Response returned after attempting to delete a group chat.
/// This response indicates whether the deletion of the group chat was successful.
/// </summary>
public record DeleteGroupChatResponse(bool Success);