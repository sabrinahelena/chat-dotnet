using Application;
using Infrastructure;
using Infrastructure.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Chat;

public class Startup(IConfiguration configuration)
{
    private IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.RegisterApplicationUseCases();
        services.RegisterExternalDependencies(Configuration);
    }

    public void Configure(IApplicationBuilder app, IConfiguration configuration)
    {
        ExecuteMigration();
    }

    private void ExecuteMigration()
    {
        var connectionString = Configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<ChatDbContext>();
        optionsBuilder.UseNpgsql(connectionString ?? string.Empty);
        using var dbContext = new ChatDbContext(optionsBuilder.Options);
        dbContext.Database.Migrate();
    }
}