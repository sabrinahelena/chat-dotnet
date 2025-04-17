using Domain.Entities;
using Domain.SeedWork;

namespace Domain.Interfaces.Repositories;

public interface IUserRepository: IRepository
{
    Task AddAsync(UserEntity entity, CancellationToken cancellationToken);
}