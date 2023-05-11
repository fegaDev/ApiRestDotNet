using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        // Establecer relaciones Course a Category

        [Required]
        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
