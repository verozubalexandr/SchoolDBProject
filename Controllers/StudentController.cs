using Microsoft.AspNetCore.Mvc;
using SchoolDBProject.Models;
using SchoolDBProject.Services;

namespace SchoolDBProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        //get all students
        [HttpGet("get-all-students")]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            if (students == null || !students.Any())
            {
                return NotFound("No students found.");
            }
            return Ok(students);
        }

        //get student by id
        [HttpGet("get-student/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(student);
        }

        //add new student
        [HttpPost("add-student")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student cannot be null.");
            }

            _studentService.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        //update existing student
        [HttpPut("update-student/{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentDTO studentDto)
        {
            try
            {
                _studentService.UpdateStudent(id, studentDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //delete student by id
        [HttpDelete("delete-student/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
