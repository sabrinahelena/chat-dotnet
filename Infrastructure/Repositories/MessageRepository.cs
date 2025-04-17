using Domain.Interfaces.Repositories;
using Domain.SeedWork;

namespace Infrastructure.Repositories;

public class MessageRepository: IMessageRepository
{
    public IUnitOfWork UnitOfWork { get; }
}