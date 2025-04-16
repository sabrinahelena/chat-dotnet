using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.SeedWork;

public abstract class Entity
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid? Id { get; set; }

    protected Entity()
    {
        Id ??= Guid.NewGuid();
    }
}