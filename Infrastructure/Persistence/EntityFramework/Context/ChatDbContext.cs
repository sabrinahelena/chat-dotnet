using System.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityFramework.Context;

public class ChatDbContext: DbContext
{
    public IDbConnection Connection => base.Database.GetDbConnection();
    
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<MessageEntity> Messages { get; set; }
    public DbSet<GroupChatEntity> GroupChats { get; set; }

    public ChatDbContext(DbContextOptions<ChatDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ////These configurations are useful while debuging the code. DON'T USE IN PRODUCTION
        // optionsBuilder
        //    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
        //     .EnableDetailedErrors()
        //     .EnableSensitiveDataLogging()
        // .UseNpgsql("Host=localhost;Port=5432;Database=chatsystem;Username=postgres;Password=password;");

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}