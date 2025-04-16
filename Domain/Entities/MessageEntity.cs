using Domain.SeedWork;

namespace Domain.Entities;

public class MessageEntity: Entity
{
    public string Content { get; set; }
    public UserEntity Sender { get; set; }
    public UserEntity? Receiver { get; set; }
    public DateTime SentAt { get; set; }
    public GroupChatEntity? GroupChat { get; set; }
}