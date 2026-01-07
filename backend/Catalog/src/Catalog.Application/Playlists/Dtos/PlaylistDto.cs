using Catalog.Application.Tracks.Dtos;

namespace Catalog.Application.Playlists.Dtos;

public record  PlaylistDto(
    Guid Id,
    string Title,
    int Count,
    ICollection<PlaylistTrackDto> Tracks
);
