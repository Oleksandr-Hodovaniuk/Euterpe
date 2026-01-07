namespace Catalog.Application.Tracks.Dtos;

public record PlaylistTrackDto(
    TrackDto Track,
    DateTime AddedAt
);
