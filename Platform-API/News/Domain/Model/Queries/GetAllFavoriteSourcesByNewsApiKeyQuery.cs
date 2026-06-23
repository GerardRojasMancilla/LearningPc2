using Platform_API.News.Domain.Model.ValueObjects;

namespace Platform_API.News.Domain.Model.Queries;

/// <summary>
///     Query to get all favorite sources by NewsApiKey
/// </summary>
/// <param name="NewsApiKey">The NewsApiKey to search</param>
public record GetAllFavoriteSourcesByNewsApiKeyQuery(NewsApiKey NewsApiKey);