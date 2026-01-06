using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Catalog.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Playlist> Playlists { get; }
    DbSet<Track> Tracks { get; }
    DbSet<PlaylistTrack> PlaylistTracks { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}
