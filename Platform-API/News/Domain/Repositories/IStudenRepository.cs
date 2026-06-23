/*
using Platform_API.Education.Domain.Model.Aggregates;
using Platform_API.Education.Domain.Model.ValueObjects;
using Platform_API.Shared.Domain.Repositories;

namespace Platform_API.Education.Domain.Repositories;

/// <summary>
///     Contrato del repositorio de Estudiantes.
///     Herencia de IBaseRepository proporciona: AddAsync, ListAsync, Remove.
/// </summary>
public interface IStudentRepository : IBaseRepository<Student>
{
    // --- BÚSQUEDAS PERSONALIZADAS ---

    /// <summary> Buscar por ID (opcional) </summary>
    Task<Student?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary> Buscar por DNI (criterio de negocio clave) </summary>
    Task<Student?> FindByDniAsync(StudentDni dni, CancellationToken cancellationToken = default);

    // --- MÉTODOS DE VALIDACIÓN (Muy usados) ---

    /// <summary> Verificar si ya existe alguien con este email (para evitar duplicados) </summary>
    Task<bool> ExistsByEmailAsync(StudentEmail email, CancellationToken cancellationToken = default);

    /// <summary> Verificar si el DNI ya está registrado en el sistema </summary>
    Task<bool> ExistsByDniAsync(StudentDni dni, CancellationToken cancellationToken = default);

    // --- MÉTODOS DE LISTADO FILTRADO (Filtros comunes) ---

    /// <summary> Obtener estudiantes activos </summary>
    Task<IEnumerable<Student>> ListActiveAsync(CancellationToken cancellationToken = default);
}
*/