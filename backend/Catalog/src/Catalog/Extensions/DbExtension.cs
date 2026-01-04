using Catalog.Application.Interfaces;

namespace Catalog.Extensions;

public static class DbExtension
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbInitialiser = scope.ServiceProvider.GetRequiredService<IApplicationDbContextInitialiser>();

        await dbInitialiser.InitialiseAsync();
        await dbInitialiser.SeedAsync();
    }
}
