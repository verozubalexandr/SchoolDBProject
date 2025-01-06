using System.ComponentModel.DataAnnotations;

namespace SchoolDBProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int[] SubjectIds { get; set; }

        [Range(1, 50)]
        public int ExperienceYears { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Pesel { get; set; }

        public string Position { get; set; } 

        public int[] ClassIds { get; set; }
    }
}
