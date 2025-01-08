using System.ComponentModel.DataAnnotations;

namespace SchoolDBProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        public int[] SubjectIds { get; set; }

        [Range(0, 50, ErrorMessage = "Experience must be between 0 and 50 years.")]
        public int ExperienceYears { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pesel is required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Pesel must be exactly 11 characters.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Pesel must contain only digits.")]
        public string Pesel { get; set; }

        public string Position { get; set; }

        public int[] ClassIds { get; set; }
    }
}

