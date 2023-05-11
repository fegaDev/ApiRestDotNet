using System.ComponentModel.DataAnnotations;
namespace UniversityApiBackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        /*Anteriormente : 
          
            public string CreatedBy { get; set; } = string.Empty;
            public string UpdatedBy { get; set; } = string.Empty;
            public string DeletedBy { get; set; } = string.Empty;
            
         */

        /* Ahora : Se establece que el CreateBy,UpdateBy y DeletedBy lo realiza un Usuario   */
        public int userID {get; set;} //En veremos, se borró en proyecto temporalmente.
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; } = string.Empty;

        public DateTime? DeletedAt { get; set; }
        public bool isDeleted { get; set; } = false;

        //Establecer relacion Usuarios a BaseEntity


    }
}
