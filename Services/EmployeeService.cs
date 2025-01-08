using SchoolDBProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDBProject.Services
{
    public class EmployeeService
    {
        private List<Employee> _employees;

        public EmployeeService()
        {
            _employees = new List<Employee>();
        }

        //add new employee
        public void AddEmployee(Employee employee)
        {
            employee.Id = GenerateId();
            _employees.Add(employee);
        }

        //get all employees
        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }

        //get employee by id
        public Employee GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        //update employee info
        public void UpdateEmployee(int id, UpdateEmployeeDTO updatedEmployee)
        {
            var employee = GetEmployeeById(id);
            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            employee.FirstName = updatedEmployee.FirstName ?? employee.FirstName;
            employee.LastName = updatedEmployee.LastName ?? employee.LastName;
            employee.Position = updatedEmployee.Position ?? employee.Position;
            employee.PhoneNumber = updatedEmployee.PhoneNumber ?? employee.PhoneNumber;
            employee.Email = updatedEmployee.Email ?? employee.Email;
        }

        //delete employee by id
        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }

        //id generation method from IIdGenerator interface
        private int GenerateId()
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            return (int)(now % int.MaxValue);
        }
    }
}
