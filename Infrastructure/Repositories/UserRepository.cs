using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.SeedWork;
using Infrastructure.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

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
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<UserEntity?> GetByLoginAsync(string login, CancellationToken cancellationToken)
    {
        return await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Login == login, cancellationToken);
    }

}