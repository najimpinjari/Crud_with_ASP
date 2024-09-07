using System.ComponentModel.DataAnnotations;

namespace Crud_with_ASP.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(100)]
        public string Designation { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }
    }
}
