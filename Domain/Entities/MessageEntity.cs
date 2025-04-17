using Domain.SeedWork;

namespace Domain.Entities;

public class MessageEntity : Entity
{
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; }

    public Guid SenderId { get; set; }
    public UserEntity Sender { get; set; }

    public Guid? ReceiverId { get; set; }
    public UserEntity? Receiver { get; set; }

    public Guid? GroupChatId { get; set; }
    public GroupChatEntity? GroupChat { get; set; }
}