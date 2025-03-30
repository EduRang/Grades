namespace Grades.Models;

public class Subject
{
    public int Id { get; set; }
    public string? Name { get; set; }

     // Lista de actividades relacionadas
    public virtual ICollection<Activity>? Activities { get; set; }

    // Lista predeterminada de materias
    public static List<Subject> DefaultSubjects = new List<Subject>
    {
        new Subject { Id = 1, Name = "Matemáticas" },
        new Subject { Id = 2, Name = "Ciencias" },
        new Subject { Id = 3, Name = "Historia" }
    };
}