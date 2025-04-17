using Infrastructure.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
   public static void RegisterExternalDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureRepositories(services);

        services.AddDbContextFactory<ChatDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<IChatDbContext, ChatDbContext>();
    }

    private static void ConfigureRepositories(IServiceCollection services)
    {
        // services.AddScoped<ISagaRepository, SagaRepository>();
        // services.AddTransient<IAgreementsAccessControlRepository, AgreementsAccessControlRepository>();
    }
}
