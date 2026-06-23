using Platform_API.News.Domain.Model.Commands;
using Platform_API.News.Domain.Model.ValueObjects;

namespace Platform_API.News.Domain.Model.Aggregates;

/// <summary>
///     Represents a favorite news source for a given News API key.
/// </summary>
public partial class FavoriteSource
{
    /// <summary>
    ///     Protected parameterless constructor for EF Core.
    /// </summary>
    protected FavoriteSource()
    {
        NewsApiKey = null!;
        SourceId = null!;
    }

    /// <summary>
    ///     Creates a new FavoriteSource from a creation command.
    /// </summary>
    /// <param name="command">The CreateFavoriteSourceCommand command</param>
    public FavoriteSource(CreateFavoriteSourceCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        NewsApiKey = command.NewsApiKey;
        SourceId = command.SourceId;
    }

    /// <summary>
    ///     Gets the server-generated identifier for this favorite source.
    /// </summary>
    public int Id { get; private set; }
    
    /// <summary>
    ///     Gets the News API key associated with this favorite source.
    /// </summary>
    public NewsApiKey NewsApiKey { get; private set; }
    
    /// <summary>
    ///     Gets the source identifier from the News API.
    /// </summary>
    public SourceId SourceId { get; private set; }
}