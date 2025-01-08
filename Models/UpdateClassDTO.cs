using System.ComponentModel.DataAnnotations;

namespace SchoolDBProject.Models
{
    public class UpdateClassDTO
    {
        public string? Name { get; set; }

        public int? TeacherId { get; set; }

        public int[]? StudentIds { get; set; }

        public int[]? SubjectIds { get; set; }
    }
}