namespace CatchUpPlatform.API.News.Domain.Model.ValueObjects;

/// <summary>
/// Represents a validated source identifier in the news domain context.
/// </summary>
/// <remarks>
/// This is a sealed record, ensuring immutability and structural equality 
/// for the source identifier.
/// </remarks> // <remarks> sirve para añadir detalles adicionales sobre el diseño de la clase.
public sealed record SourceId
{
    // Constante que define el límite de caracteres según las reglas del negocio.
    private const int MaxLength = 255;

    /// <summary>
    /// Initializes a new instance of the <see cref="SourceId"/> record.
    /// </summary>
    /// <param name="value">The raw string value representing the source identifier.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when the <paramref name="value"/> is null, empty, consists only of white-space characters,
    /// or exceeds the maximum allowed length of 255 characters.
    /// </exception> // <exception> documenta formalmente qué errores pueden salir de este constructor.
    public SourceId(string value)
    {
        // Validación 1: Evita que el identificador sea nulo, vacío o puros espacios.
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("SourceId cannot be null, empty, or whitespace.", nameof(value));

        // Validación 2: Evita que el identificador sature la base de datos superando los 255 caracteres.
        if (value.Length > MaxLength)
            throw new ArgumentException($"SourceId cannot be longer than {MaxLength} characters.", nameof(value));

        // Guarda el valor ya verificado y limpio.
        Value = value;
    }

    /// <summary>
    /// Gets the underlying primitive string value of the source identifier.
    /// </summary>
    /// <value>The encapsulated primitive string value.</value> // <value> se usa específicamente para documentar propiedades.
    public string Value { get; }

    /// <inheritdoc cref="object.ToString"/>
    // 'cref="object.ToString"' le dice explícitamente a Rider que estamos heredando la documentación
    // del método ToString original de la clase base Object de C#.
    public override string ToString() => Value;
}