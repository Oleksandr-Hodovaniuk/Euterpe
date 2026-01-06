using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Catalog.Application.Interfaces;

public interface IUnitOfWork
{
    IRepository<Playlist> Playlists { get; }
    IRepository<Track> Tracks { get; }
    IRepository<PlaylistTrack> PlaylistTracks { get; }
    Task SaveAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}
