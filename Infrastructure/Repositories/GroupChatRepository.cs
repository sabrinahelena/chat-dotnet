using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.SeedWork;
using Infrastructure.Persistence.EntityFramework.Context;

namespace Infrastructure.Repositories;

public class GroupChatRepository(IChatDbContext context) : IGroupChatRepository
{
    public IUnitOfWork UnitOfWork => context;
    
    public async Task AddAsync(UserEntity entity, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(entity, cancellationToken);
    }
}