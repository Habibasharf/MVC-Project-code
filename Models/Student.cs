
using System.ComponentModel.DataAnnotations;

namespace MVCNew_project.Models
{
    public class Student
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Enter value")]
        [StringLength(10, MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter value")]
        [Range(10, 40)]
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter value")]
        public string Email { get; set; }
        public string ImageName { get; set; }
    }
}
