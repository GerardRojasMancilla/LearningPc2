using Platform_API.Education.Domain.Model.Commands;
//using Platform_API.Education.Domain.Model.ValueObjects;
//using Platform_API.Shared.Domain.Model.Aggregates;

//namespace Platform_API.Education.Domain.Model.Aggregates;

public partial class Student {
    
    //public int Id { get; private set; }
    //public StudentName Name { get; private set; }
    //public StudentEmail Email { get; private set; }

    //protected Student() { Name = null!; Email = null!; }

    // Constructor que actúa como factory recibiendo el Comando
    public Student(RegisterStudentCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        //Name = command.FullName;
        //Email = command.Email;
    }
}