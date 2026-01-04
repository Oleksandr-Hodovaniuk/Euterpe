using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Persistence;

internal class ApplicationDbContextInitialiser(ApplicationDbContext _context)
    : IApplicationDbContextInitialiser
{
    public async Task InitialiseAsync(CancellationToken cancellationToken = default)
    {
        if (_context.Database.IsNpgsql())
        {
            await _context.Database.MigrateAsync(cancellationToken);

        }
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (await _context.Tracks.AnyAsync(cancellationToken))
            return;

        var track1 = new Track
        {
            Id = Guid.NewGuid(),
            KeyCloakUserId = Guid.NewGuid(),
            Title = "qqqqq",
            Artist = "jjkhhjh",
            Duration = 189,
            Rating = 5,
            FilePath = "/qew/we/qwe"
        };

        var track2 = new Track
        {
            Id = Guid.NewGuid(),
            KeyCloakUserId = Guid.NewGuid(),
            Title = "eeeeeeee",
            Artist = "sadqwedawe",
            Duration = 289,
            Rating = 4,
            FilePath = "/qew/we/qwe"
        };

        var track3 = new Track
        {
            Id = Guid.NewGuid(),
            KeyCloakUserId = Guid.NewGuid(),
            Title = "ssssss",
            Artist = "jiojiouyh",
            Duration = 350,
            Rating = 3,
            FilePath = "/qew/we/qwe"
        };

        var track4 = new Track
        {
            Id = Guid.NewGuid(),
            KeyCloakUserId = Guid.NewGuid(),
            Title = "ffffff",
            Artist = "ujytfrtr",
            Duration = 234,
            Rating = 2,
            FilePath = "/qew/we/qwe"
        };

        var track5 = new Track
        {
            Id = Guid.NewGuid(),
            KeyCloakUserId = Guid.NewGuid(),
            Title = "ttttttt",
            Artist = "eqwgtrgyrt",
            Duration = 322,
            Rating = 5,
            FilePath = "/qew/we/qwe"
        };

        await _context.Tracks.AddRangeAsync(track1, track2, track2, track3, track4, track5);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
