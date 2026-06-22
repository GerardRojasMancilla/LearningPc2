namespace Platform_API.News.Domain.Model.ValueObjects;

/// <summary>
/// Objeto de valor que representa una clave API de noticias (News API key) validada.
/// </summary>
public sealed record NewsApiKey
{
    // Define el tamaño máximo que aceptará la base de datos MySQL (VARCHAR(255))
    private const int MaxLength = 255;

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="NewsApiKey"/> validando el texto ingresado.
    /// </summary>
    /// <param name="value">La clave API en texto bruto. No debe ser nula, ni vacía, ni pasar los 255 caracteres.</param>
    /// <exception cref="ArgumentException">Se dispara si el valor es inválido o demasiado largo.</exception>
    public NewsApiKey(string value)
    {
        // REGLA 1: Validar que el usuario no haya enviado un texto vacío, nulo o puros espacios
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La clave API de noticias no puede ser nula, vacía o espacios en blanco.", nameof(value));

        // REGLA 2: Validar que el texto no supere el tamaño máximo de la base de datos
        if (value.Length > MaxLength)
            throw new ArgumentException($"La clave API de noticias no puede tener más de {MaxLength} caracteres.", nameof(value));

        // Si pasó las dos reglas de arriba, el valor es totalmente válido y se guarda
        Value = value;
    }

    /// <summary>
    /// Propiedad de solo lectura que guarda el texto limpio y validado.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Sobreescribe el comportamiento por defecto para que al transformar este objeto a texto, devuelva el string real.
    /// </summary>
    public override string ToString() => Value;
}