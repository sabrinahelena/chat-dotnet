using Domain.SeedWork;

namespace Domain.Entities;

/// <summary>
/// Represents a user entity in the domain.
/// This entity contains information about a user, including their name, login credentials, and associated group chats.
/// </summary>
public class UserEntity : Entity
{
    /// <summary>
    /// The name of the user.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// The unique login (username) of the user.
    /// </summary>
    public string Login { get; private set; } = string.Empty;

    /// <summary>
    /// The password of the user. This is stored securely.
    /// </summary>
    public string Password { get; private set; } = string.Empty;

    /// <summary>
    /// A collection of group chats the user is a member of.
    /// </summary>
    public ICollection<GroupChatEntity>? GroupChats { get; set; } = new List<GroupChatEntity>();

    /// <summary>
    /// Protected constructor for the entity, used by the ORM or for object initialization without data.
    /// </summary>
    protected UserEntity()
    {
        
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserEntity"/> class with specified name, login, and password.
    /// </summary>
    /// <param name="name">The name of the user.</param>
    /// <param name="login">The login (username) of the user.</param>
    /// <param name="password">The password for the user.</param>
    public UserEntity(string name, string login, string password)
    {
        Name = name;
        Login = login;
        Password = password;
    }
}
