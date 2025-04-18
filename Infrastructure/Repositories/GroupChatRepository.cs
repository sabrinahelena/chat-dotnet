using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.SeedWork;
using Infrastructure.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// Repository for managing group chat entities in the database.
/// This class implements the <see cref="IGroupChatRepository"/> interface and provides methods to interact
/// with group chat data stored in the database using Entity Framework.
/// </summary>
public class GroupChatRepository(IChatDbContext context) : IGroupChatRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async Task AddAsync(GroupChatEntity entity, CancellationToken cancellationToken)
    => await context.GroupChats.AddAsync(entity, cancellationToken);

    public void Remove(GroupChatEntity entity)
        => context.GroupChats.Remove(entity);

    public async Task<GroupChatEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await context.GroupChats
            .Include(gc => gc.Members)
            .Include(gc => gc.Messages)
            .FirstOrDefaultAsync(gc => gc.Id == id, cancellationToken);

    public async Task<IEnumerable<GroupChatEntity>> GetAllAsync(CancellationToken cancellationToken)
        => await context.GroupChats
            .Include(gc => gc.Members)
            .ToListAsync(cancellationToken);

    public void Update(GroupChatEntity groupChatEntity)
        => context.GroupChats.Update(groupChatEntity);

}