using Catalog.Application.Tracks.AutoMappers;
using Catalog.Application.Tracks.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(GetTracksHandler).Assembly);
        });

        services.AddAutoMapper(cfg => cfg.AddMaps(typeof(TrackProfile).Assembly));

        return services;
    }
}
