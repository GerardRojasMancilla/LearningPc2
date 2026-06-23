using Humanizer;

namespace Platform_API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     String extension methods for text conversion and pluralization in persistence layer.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    ///     Converts a PascalCase string to snake_case (e.g., NewsApiKey to news_api_key).
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The snake_case representation of the string.</returns>
    public static string ToSnakeCase(this string text)
    {
        if (string.IsNullOrEmpty(text)) return text;
        
        return new string(Convert(text.GetEnumerator()).ToArray());

        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if (!e.MoveNext()) yield break;

            yield return char.ToLower(e.Current);

            while (e.MoveNext())
                if (char.IsUpper(e.Current))
                {
                    yield return '_';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
        }
    }

    /// <summary>
    ///     Pluralizes a string using the Humanizer library.
    /// </summary>
    /// <param name="text">The string to pluralize.</param>
    /// <returns>The pluralized string.</returns>
    public static string ToPlural(this string text)
    {
        return text.Pluralize(false);
    }
}