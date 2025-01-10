using Microsoft.AspNetCore.Mvc;
using SchoolDBProject.Models;
using SchoolDBProject.Services;

namespace SchoolDBProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //get all employees
        [HttpGet("get-all-employees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            if (employees == null || !employees.Any())
            {
                return NotFound("No employees found.");
            }
            return Ok(employees);
        }

        //get employee by id
        [HttpGet("get-employee/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }
            return Ok(employee);
        }

        //get employees by name or last name
        [HttpGet("get-employees-by-name")]
        public IActionResult GetEmployeesByName([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name query parameter is required.");
            }

            var employees = _employeeService.GetEmployeesByName(name);
            if (employees == null || !employees.Any())
            {
                return NotFound($"No employees found with name or surname containing '{name}'.");
            }

            return Ok(employees);
        }

        //add new employee
        [HttpPost("add-employee")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee cannot be null.");
            }

            _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        //update existing employee
        [HttpPut("update-employee/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployeeDTO employeeDto)
        {
            try
            {
                _employeeService.UpdateEmployee(id, employeeDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //delete employee by id
        [HttpDelete("delete-employee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            _employeeService.DeleteEmployee(id);
            return NoContent();
        }
    }
}
