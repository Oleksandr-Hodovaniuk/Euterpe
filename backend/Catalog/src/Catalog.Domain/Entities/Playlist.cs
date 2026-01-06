using Catalog.Domain.Common;

namespace Catalog.Domain.Entities;

public class Playlist : BaseEntity
{
    public Guid KeyCloakUserId { get; set; }
    public string Title { get; set; } = null!;
    public int Count { get; set; } = 0;
    public ICollection<PlaylistTrack>? PlaylistTracks { get; set; }
}
