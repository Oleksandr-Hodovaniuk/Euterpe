using Catalog.Application.Interfaces;
using Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;

namespace Catalog.Infrastructure.Extensions;

public static class DbConnectionExtension
{
    public static IServiceCollection AddPostgreSqlConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var host = Environment.GetEnvironmentVariable("CATALOG_DB_HOST");
        var port = Environment.GetEnvironmentVariable("CATALOG_DB_PORT");
        var dbName = Environment.GetEnvironmentVariable("CATALOG_DB_NAME");
        var user = Environment.GetEnvironmentVariable("CATALOG_DB_USER");
        var password = Environment.GetEnvironmentVariable("CATALOG_DB_PASSWORD");

        // For local development, use localhost instead of docker hostname
        var connectionString = $"Host={host};Port={port};Database={dbName};Username={user};Password={password};";

        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseNpgsql(connectionString));

        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
