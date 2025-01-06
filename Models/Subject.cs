using System.ComponentModel.DataAnnotations;

namespace SchoolDBProject.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public string Description { get; set; }

        public int[] ClassIds { get; set; }
    }
}
