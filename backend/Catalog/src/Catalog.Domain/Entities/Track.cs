using Catalog.Domain.Common;

namespace Catalog.Domain.Entities;

public class Track : BaseEntity
{
    public Guid KeyCloakUserId { get; set; }
    public string Title { get; set; } = null!;
    public string? Artist { get; set; }
    public int Duration { get; set; }
    public byte? Rating { get; set; }
    public string? FilePath { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
