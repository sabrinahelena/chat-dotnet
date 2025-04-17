using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.EntityFramework.Context;

public class ChatDbContextFactory: IDesignTimeDbContextFactory<ChatDbContext>
{
    private readonly IConfiguration _configuration;

    public ChatDbContextFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ChatDbContextFactory()
    {
    }

    public ChatDbContext CreateDbContext(string[] args)
    {
        string connectionString = _configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        var optionsBuilder = new DbContextOptionsBuilder<ChatDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return new ChatDbContext(optionsBuilder.Options);
    }
}