
/*
using Platform_API.Education.Domain.Model.Commands;
using Platform_API.Education.Domain.Model.ValueObjects;

namespace Platform_API.Education.Domain.Model.Aggregates;

/// <summary>
///     Representa a un estudiante en el sistema educativo.
/// </summary>
public partial class Student
{
    /// <summary>
    ///     Constructor protegido sin parámetros para EF Core.
    ///     Obligatorio para que Entity Framework pueda reconstruir la entidad desde la base de datos.
    /// </summary>
    protected Student()
    {
        Name = null!;
        Email = null!;
        Dni = null!;
    }

    /// <summary>
    ///     Constructor Factory: Crea un nuevo Student a partir de un comando.
    ///     Actúa como el manejador de creación para RegisterStudentCommand.
    /// </summary>
    /// <param name="command">El comando con los datos del estudiante.</param>
    public Student(RegisterStudentCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        Name = command.Name;
        Email = command.Email;
        Dni = command.Dni;
    }

    /// <summary>
    ///     Identificador único generado por el servidor.
    /// </summary>
    public int Id { get; private set; }
    
    /// <summary>
    ///     Nombre del estudiante.
    /// </summary>
    public StudentName Name { get; private set; }
    
    /// <summary>
    ///     Correo electrónico del estudiante.
    /// </summary>
    public StudentEmail Email { get; private set; }

    /// <summary>
    ///     Documento Nacional de Identidad del estudiante.
    /// </summary>
    public StudentDni Dni { get; private set; }
}
*/