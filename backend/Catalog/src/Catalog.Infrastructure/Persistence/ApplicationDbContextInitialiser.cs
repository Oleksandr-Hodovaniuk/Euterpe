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

        var userId = Guid.NewGuid();

        var plalistId1 = Guid.NewGuid();
        var plalistId2 = Guid.NewGuid();

        var trackId1 = Guid.NewGuid();
        var trackId2 = Guid.NewGuid();
        var trackId3 = Guid.NewGuid();

        _context.Playlists.AddRange(
            new Playlist {
                Id = plalistId1,
                KeyCloakUserId = userId,
                Title = "Rock",
                Count = 2
            },
            new Playlist
            {
                Id = plalistId2,
                KeyCloakUserId = userId,
                Title = "Chill",
                Count = 1
            }
        );

        _context.Tracks.AddRange(
            new Track {
                Id = trackId1,
                KeyCloakUserId = userId,
                Title = "Iron beast",
                Artist = "Winter woolfs",
                Duration = 220,
                Rating = 4,
                FileKey = "/tracks/"
            },
            new Track
            {
                Id = trackId2,
                KeyCloakUserId = userId,
                Title = "WW3",
                Artist = "RadioRoaches",
                Duration = 267,
                Rating = 5,
                FileKey = "/tracks/"
            },
            new Track
            {
                Id = trackId3,
                KeyCloakUserId = userId,
                Title = "Just a guy",
                Artist = "Sweet Day",
                Duration = 293,
                Rating = 3,
                FileKey = "/tracks/"
            }
        );

        //await _context.SaveChangesAsync(cancellationToken);

        _context.PlaylistTracks.AddRange(
            new PlaylistTrack {
                PlaylistId = plalistId1,
                TrackId = trackId1
            },
            new PlaylistTrack
            {
                PlaylistId = plalistId1,
                TrackId = trackId2
            },
            new PlaylistTrack
            {
                PlaylistId = plalistId2,
                TrackId = trackId3
            }
        );

        await _context.SaveChangesAsync(cancellationToken);
    }
}
