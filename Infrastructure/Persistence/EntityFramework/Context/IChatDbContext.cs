using System.Data;
using Domain.Entities;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityFramework.Context;

public interface IChatDbContext: IUnitOfWork
{
    DbSet<UserEntity> Users { get; set; }
    DbSet<MessageEntity> Messages { get; set; }
    DbSet<GroupChatEntity> GroupChats { get; set; }
    IDbConnection Connection { get; }
}