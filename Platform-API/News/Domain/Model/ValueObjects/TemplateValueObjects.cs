using System.Text.RegularExpressions;

namespace Platform_API.News.Domain.Model.ValueObjects;

// =========================================================================
// PLANTILLA 1: TEXTO VALIDADO (Ejemplo original: SourceId)
// Use: Para nombres, identificadores, títulos, códigos de texto estándar.
// =========================================================================
public sealed record SourceIdN2
{
    private const int MaxLength = 255;

    public SourceIdN2(string value)
    {
        // Regla obligatoria para textos: que no venga vacío ni con puros espacios
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("SourceId cannot be null, empty, or whitespace.", nameof(value));

        // Regla obligatoria para textos: proteger el tamaño máximo en la Base de Datos
        if (value.Length > MaxLength)
            throw new ArgumentException($"SourceId cannot be longer than {MaxLength} characters.", nameof(value));

        Value = value;
    }

    public string Value { get; }
    public override string ToString() => Value;
}


// =========================================================================
// PLANTILLA 2: NÚMERO CON RANGO (Ejemplo: SourceRating)
// Use: Para puntuaciones, cantidades limitadas, edades, montos mínimos/máximos.
// =========================================================================
public sealed record SourceRating
{
    private const int MinStars = 1;
    private const int MaxStars = 5;

    public SourceRating(int value)
    {
        // Regla para números: Validar límites aritméticos usando los operadores < o >
        if (value < MinStars || value > MaxStars)
            throw new ArgumentException($"Rating must be between {MinStars} and {MaxStars}.", nameof(value));

        Value = value;
    }

    // ¡OJO! El tipo de dato aquí cambia al primitivo correspondiente: 'int'
    public int Value { get; }
    public override string ToString() => Value.ToString();
}


// =========================================================================
// PLANTILLA 3: FORMATO ESPECÍFICO / EXPRESIÓN REGULAR (Ejemplo: SubscriberEmail)
// Use: Para correos, URLs, números de teléfono, DNI o estructuras rígidas.
// =========================================================================
public sealed record SubscriberEmail
{
    private const int MaxLength = 150;
    
    // El Regex se declara estático y de solo lectura para optimizar el rendimiento
    private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public SubscriberEmail(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be null or empty.", nameof(value));

        if (value.Length > MaxLength)
            throw new ArgumentException($"Email cannot exceed {MaxLength} characters.", nameof(value));

        // Regla de formato: Si el texto no encaja perfectamente con el patrón Regex, rebota
        if (!EmailRegex.IsMatch(value))
            throw new ArgumentException("The provided string is not a valid email address.", nameof(value));

        // Buenas prácticas opcionales: limpiar espacios sueltos (.Trim) y estandarizar a minúsculas
        Value = value.Trim().ToLower();
    }

    public string Value { get; }
    public override string ToString() => Value;
}


// =========================================================================
// PLANTILLA 4: ESTADO BOOLEANO / FLAG (Ejemplo: IsActiveSource)
// Use: Para estados (Activo/Inactivo, Aprobado/Pendiente, Visible/Oculto).
// =========================================================================
public sealed record IsActiveSource
{
    public IsActiveSource(bool value)
    {
        // Usualmente los booleanos no llevan validación 'if' porque solo pueden ser true o false,
        // pero meterlos en un Value Object le da un significado de negocio (semántica).
        Value = value;
    }

    // ¡OJO! El tipo de dato aquí cambia a 'bool'
    public bool Value { get; }

    // MÉTODOS DE FÁBRICA (Factory Methods) - Super útiles para el examen:
    // Permiten inicializar el estado de manera súper expresiva y limpia en tus constructores.
    public static IsActiveSource AsActive() => new(true);
    public static IsActiveSource AsInactive() => new(false);

    public override string ToString() => Value.ToString();
}