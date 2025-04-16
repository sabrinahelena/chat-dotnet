using Domain.SeedWork;

namespace Domain.Entities;

public class GroupChatEntity: Entity
{
    public DateTime CreatedAt { get; set; }
    public ICollection<MessageEntity>? Messages { get; set; } = [];
    public ICollection<UserEntity>? Members { get; set; } = [];
}