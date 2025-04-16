using Domain.SeedWork;

namespace Domain.Entities;

public class UserEntity: Entity
{
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}