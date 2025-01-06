using System.ComponentModel.DataAnnotations;

namespace SchoolDBProject.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Range(6, 18)]
        public int Age { get; set; }

        [Required]
        public int ClassId { get; set; } 

        [Phone]
        public string PhoneNumber { get; set; } 

        [EmailAddress]
        public string Email { get; set; } 

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Pesel { get; set; } 

        public int[] ParentIds { get; set; }
    }
}
