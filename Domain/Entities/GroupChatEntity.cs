using Domain.SeedWork;

namespace Domain.Entities;

/// <summary>
/// Represents a group chat entity in the domain.
/// This entity contains information about a group chat room, including its creation date,
/// messages, and members of the chat.
/// </summary>
public class GroupChatEntity : Entity
{
    /// <summary>
    /// The date and time when the group chat was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A collection of messages exchanged in the group chat.
    /// This collection holds all messages that have been sent in this group chat room.
    /// </summary>
    public ICollection<MessageEntity>? Messages { get; set; } = [];

    /// <summary>
    /// A collection of users who are members of the group chat.
    /// This collection holds all the users who are part of the group chat.
    /// </summary>
    public ICollection<UserEntity>? Members { get; set; } = [];
}
