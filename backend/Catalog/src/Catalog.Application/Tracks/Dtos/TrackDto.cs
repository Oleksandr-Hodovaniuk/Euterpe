namespace Catalog.Application.Tracks.Dtos;

public record TrackDto(
    Guid Id,
    string Title,
    string? Artist,
    int? Duration,
    byte? Rating,
    bool HasFile,
    DateTime CreatedAt
);
