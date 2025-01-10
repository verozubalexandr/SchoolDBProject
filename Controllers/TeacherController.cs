using Microsoft.AspNetCore.Mvc;
using SchoolDBProject.Models;
using SchoolDBProject.Services;

namespace SchoolDBProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly TeacherService _teacherService;

        public TeachersController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        //get all teachers
        [HttpGet("get-all-teachers")]
        public IActionResult GetAllTeachers()
        {
            return Ok(_teacherService.GetAllTeachers());
        }

        //get teacher by id
        [HttpGet("get-teacher/{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        //get teachers by subject id
        [HttpGet("get-teachers-by-subject/{subjectId}")]
        public IActionResult GetTeachersBySubjectId(int subjectId)
        {
            var teachers = _teacherService.GetTeachersBySubjectId(subjectId);
            if (teachers == null || !teachers.Any())
            {
                return NotFound($"No teachers found for subject {subjectId}.");
            }
            return Ok(teachers);
        }

        //get teachers by name
        [HttpGet("get-teachers-by-name")]
        public IActionResult GetTeachersByName([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name query parameter is required.");
            }

            var teachers = _teacherService.GetTeachersByName(name);
            if (teachers == null || !teachers.Any())
            {
                return NotFound($"No teachers found with name or surname containing '{name}'.");
            }

            return Ok(teachers);
        }

        //add new teacher
        [HttpPost("add-teacher")]
        public IActionResult AddTeacher([FromBody] Teacher teacher)
        {
            if (teacher == null)
            {
                return BadRequest("Teacher cannot be null.");
            }

            _teacherService.AddTeacher(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }

        //update existing teacher
        [HttpPut("update-teacher/{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] UpdateTeacherDTO teacherDto)
        {
            try
            {
                _teacherService.UpdateTeacher(id, teacherDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //delete teacher by id
        [HttpDelete("delete-teacher/{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            _teacherService.DeleteTeacher(id);
            return NoContent();
        }
    }
}