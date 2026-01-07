using Catalog.Application.Tracks.AutoMappers;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddMaps(typeof(TrackProfile).Assembly));

        return services;
    }
}
