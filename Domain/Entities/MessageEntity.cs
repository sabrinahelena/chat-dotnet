using Domain.SeedWork;

namespace Domain.Entities;

/// <summary>
/// Represents a message entity in the domain.
/// This entity contains information about a message, including its content, timestamp,
/// sender and receiver details, and the associated group chat (if applicable).
/// </summary>
public class MessageEntity : Entity
{
    /// <summary>
    /// The content (text) of the message.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// The date and time when the message was sent.
    /// </summary>
    public DateTime SentAt { get; set; }

    /// <summary>
    /// The unique identifier of the sender of the message.
    /// </summary>
    public Guid SenderId { get; set; }

    /// <summary>
    /// The user who sent the message.
    /// </summary>
    public UserEntity Sender { get; set; }

    /// <summary>
    /// The unique identifier of the receiver of the message (if it is a direct message).
    /// This is nullable as group chats may not have a single receiver.
    /// </summary>
    public Guid? ReceiverId { get; set; }

    /// <summary>
    /// The user who received the message (if it is a direct message).
    /// This is nullable for group messages.
    /// </summary>
    public UserEntity? Receiver { get; set; }

    /// <summary>
    /// The unique identifier of the group chat to which the message belongs.
    /// This is nullable for direct messages.
    /// </summary>
    public Guid? GroupChatId { get; set; }

    /// <summary>
    /// The group chat where the message was sent (if the message is part of a group chat).
    /// This is nullable for direct messages.
    /// </summary>
    public GroupChatEntity? GroupChat { get; set; }
}