using System.ComponentModel.DataAnnotations;

namespace SchoolDBProject.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Range(6, 18, ErrorMessage = "Age must be between 6 and 18.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Class ID is required.")]
        public int ClassId { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pesel is required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Pesel must be exactly 11 characters.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Pesel must contain only digits.")]
        public string Pesel { get; set; }

        public int[] ParentIds { get; set; }
    }
}
