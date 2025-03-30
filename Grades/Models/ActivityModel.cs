using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grades.Models;

[Table("Activity")]
public class Activity
{
    public int Id { get; set; }

    [ForeignKey("Subject")]  // Relación con Subject 
    public int? SubjectId { get; set; }

    [Required]
    [StringLength(50)]
    public string? Type { get; set; }

    [Range(0, 100, ErrorMessage = "Valores entre 0 y 100")]
    public decimal Grade { get; set; }

    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    // Virtual permite Lazy Loading: Solo se carga explicitamente
    public virtual Subject? Subject { get; set; }

    public static List<Activity> DefaultActivities = new List<Activity>
        {
            new Activity 
            { 
                Id = 1, 
                SubjectId = 1, // Matemáticas
                Type = "Examen Parcial", 
                Grade = 85.5m,
                Date = new DateTime(2023, 10, 15)
            },
            new Activity 
            { 
                Id = 2, 
                SubjectId = 1, // Matemáticas
                Type = "Tarea", 
                Grade = 90.0m,
                Date = new DateTime(2023, 10, 20)
            },
            new Activity 
            { 
                Id = 3, 
                SubjectId = 2, // Ciencias
                Type = "Laboratorio", 
                Grade = 78.0m,
                Date = new DateTime(2023, 10, 18)
            },
            new Activity 
            { 
                Id = 4, 
                SubjectId = 2, // Ciencias
                Type = "Proyecto", 
                Grade = 92.5m,
                Date = new DateTime(2023, 11, 5)
            },
            new Activity 
            { 
                Id = 5, 
                SubjectId = 3, // Historia
                Type = "Ensayo", 
                Grade = 88.0m,
                Date = new DateTime(2023, 11, 10)
            }
        };
}
