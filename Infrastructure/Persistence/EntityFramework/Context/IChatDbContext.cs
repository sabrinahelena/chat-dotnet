using System.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityFramework.Context;

public interface IChatDbContext
{
    DbSet<UserEntity> Users { get; set; }
    DbSet<MessageEntity> Messages { get; set; }
    DbSet<GroupChatEntity> GroupChats { get; set; }
    IDbConnection Connection { get; }
}