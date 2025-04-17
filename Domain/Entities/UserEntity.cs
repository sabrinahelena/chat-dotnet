using Domain.SeedWork;

namespace Domain.Entities;

public class UserEntity : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public ICollection<GroupChatEntity>? GroupChats { get; set; } = new List<GroupChatEntity>();
}
