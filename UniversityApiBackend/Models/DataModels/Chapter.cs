using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Chapter : BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course(); // 1 a 1
        [Required]
        public string List = string.Empty; 
    }
}
