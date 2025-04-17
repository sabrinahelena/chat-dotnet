using Application;
using Infrastructure;
using Infrastructure.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Chat;

public class Startup(IConfiguration configuration)
{
    private IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.RegisterApplicationUseCases();
        services.RegisterExternalDependencies(Configuration);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Chat API",
                Version = "v1"
            });


            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IConfiguration configuration)
    {
        ExecuteMigration();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Chat API v1");
        });

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
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