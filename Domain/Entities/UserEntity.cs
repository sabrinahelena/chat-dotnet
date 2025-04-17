using Domain.SeedWork;

namespace Domain.Entities;

public class UserEntity : Entity
{
    public string Name { get; private set; } = string.Empty;
    public string Login { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;

    public ICollection<GroupChatEntity>? GroupChats { get; set; } = new List<GroupChatEntity>();

    protected UserEntity()
    {
        
    }

    public UserEntity(string name, string login, string password)
    {
        Name = name;
        Login = login;
        Password = password;
    }
}
