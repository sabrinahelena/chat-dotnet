using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence.EntityFramework.Context;

public class ChatDbContextFactory : IDesignTimeDbContextFactory<ChatDbContext>
{
    public ChatDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ChatDbContext>();

        // todo: usar appsettings para nao expor a connection string no projeto
        const string connectionString = "Host=localhost;Port=5432;Database=chatsystem;Username=postgres;Password=password;";
        optionsBuilder.UseNpgsql(connectionString);

        return new ChatDbContext(optionsBuilder.Options);
    }
}