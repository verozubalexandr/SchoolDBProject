using SchoolDBProject.Models;

namespace SchoolDBProject.Services
{
    public class EmployeeService
    {
        private List<Employee> _employees;

        public EmployeeService()
        {
            _employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = GetEmployeeById(id);
            if (employee != null)
            {
                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.Position = updatedEmployee.Position;
                employee.PhoneNumber = updatedEmployee.PhoneNumber;
                employee.Email = updatedEmployee.Email;
                employee.Pesel = updatedEmployee.Pesel;
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}
