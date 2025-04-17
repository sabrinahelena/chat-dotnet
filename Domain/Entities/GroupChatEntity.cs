using Domain.SeedWork;

namespace Domain.Entities;

public class GroupChatEntity : Entity
{
    public DateTime CreatedAt { get; set; }

    public ICollection<MessageEntity>? Messages { get; set; } = new List<MessageEntity>();
    public ICollection<UserEntity>? Members { get; set; } = new List<UserEntity>();
}
