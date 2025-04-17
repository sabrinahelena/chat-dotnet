using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.SeedWork;
using Infrastructure.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// Repository for managing user entities in the database.
/// This class implements the <see cref="IUserRepository"/> interface and provides methods to interact
/// with user data stored in the database using Entity Framework.
/// </summary>
public class UserRepository(IChatDbContext context) : IUserRepository
{
    public IUnitOfWork UnitOfWork => context;
    
    public async Task AddAsync(UserEntity entity, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(entity, cancellationToken);
    }

    public async Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<UserEntity?> GetByLoginAsync(string login, CancellationToken cancellationToken)
    {
        return await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Login == login, cancellationToken);
    }

}