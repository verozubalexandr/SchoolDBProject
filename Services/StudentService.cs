using SchoolDBProject.Interfaces;
using SchoolDBProject.Models;

namespace SchoolDBProject.Services
{
    public class StudentService : IIdGenerator
    {
        private List<Student> _students;

        //create students list
        public StudentService(ParentService parentService)
        {
            _students = new List<Student>();
        }

        //add new student
        public void AddStudent(Student student)
        {
            student.Id = GenerateId();
            _students.Add(student);
        }

        //get all students
        public List<Student> GetAllStudents()
        {
            return _students;
        }

        //get student by id
        public Student GetStudentById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        //update student's info
        public void UpdateStudent(int id, UpdateStudentDTO updatedStudent)
        {
            var student = GetStudentById(id);
            if (student == null)
            {
                throw new ArgumentException("Student not found");
            }

            student.FirstName = updatedStudent.FirstName ?? student.FirstName;
            student.LastName = updatedStudent.LastName ?? student.LastName;
            if (updatedStudent.Age.HasValue)
            {
                student.Age = updatedStudent.Age.Value;
            }
            if (updatedStudent.ClassId.HasValue)
            {
                student.ClassId = updatedStudent.ClassId.Value;
            }
            student.PhoneNumber = updatedStudent.PhoneNumber ?? student.PhoneNumber;
            student.Email = updatedStudent.Email ?? student.Email;
            student.ParentIds = updatedStudent.ParentIds ?? student.ParentIds;
        }

        //delete student by id
        public void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                _students.Remove(student);
            }
        }

        //id generation method from IIdGenerator interface
        public int GenerateId()
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            return (int)(now % int.MaxValue);
        }
    }
}
