using Platform_API.Shared.Domain.Model;

namespace Platform_API.News.Domain.Model.Aggregates;

/// <summary>
///     Audit extension for FavoriteSource aggregate.
/// </summary>
public partial class FavoriteSource : IAuditableEntity
{
    /// <summary>
    ///     Gets the timestamp when this favorite source was created.
    /// </summary>
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    ///     Gets the timestamp when this favorite source was last updated.
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }
}