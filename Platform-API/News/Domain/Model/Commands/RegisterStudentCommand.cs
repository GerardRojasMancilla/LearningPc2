/*
using Platform_API.Education.Domain.Model.ValueObjects;
*/

namespace Platform_API.Education.Domain.Model.Commands;

/// <summary>
///     Command to register a new student in the education system.
/// </summary>
/// <param name="FullName">The validated student full name</param>
/// <param name="Email">The validated student email address</param>
/// <param name="Dni">The student identity document number</param>
public record RegisterStudentCommand(
    //
    //StudentName FullName, 
    //StudentEmail Email, 
    //StudentDni Dni
); 
// Nota: Usamos 'record' porque es inmutable y garantiza la integridad de los datos
// mientras el comando viaja desde el Controller hasta el Service.