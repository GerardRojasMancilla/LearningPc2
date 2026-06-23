namespace Platform_API.Shared.Domain.Model;

/// <summary>
/// Marks an entity as carrying audit timestamps managed automatically by the persistence layer.
/// </summary>
/// <remarks>
/// Any entity in any bounded context that implements this interface will automatically 
/// have <see cref="CreatedAt"/> set once on first persistence and <see cref="UpdatedAt"/>
/// refreshed on every subsequent save, via the centralized <c>AuditableEntityInterceptor</c>.
/// </remarks> // Un interceptor es un vigilante en Infrastructure que inyecta la hora actual antes de guardar en MySQL.
public interface IAuditableEntity
{
    /// <summary>
    /// Gets or sets the UTC timestamp when the entity was first persisted in the database.
    /// </summary>
    /// <value>The nullable DateTimeOffset representing the creation moment in UTC.</value> 
    // Usamos DateTimeOffset porque guarda la fecha, la hora y la zona horaria global, evitando desfases horarios.
    DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp when the entity was last modified or saved.
    /// </summary>
    /// <value>The nullable DateTimeOffset representing the last update moment in UTC.</value>
    DateTimeOffset? UpdatedAt { get; set; }
}