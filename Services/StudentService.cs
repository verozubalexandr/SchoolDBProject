using SchoolDBProject.Interfaces;
using SchoolDBProject.Models;
using SchoolDBProject.Utils;

namespace SchoolDBProject.Services
{
    public class StudentService : IIdGenerator
    {
        private readonly string _filePath = "DBFiles/students.json";
        private List<Student> _students;

        //create students list
        public StudentService(ParentService parentService)
        {
            //_students = new List<Student>();
            _students = JsonDataStore.LoadData<Student>(_filePath);
        }

        //add new student
        public void AddStudent(Student student)
        {
            student.Id = GenerateId();
            _students.Add(student);

            JsonDataStore.SaveData(_filePath, _students);
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

        //get student by class id
        public List<Student> GetStudentsByClassId(int classId)
        {
            return _students.Where(s => s.ClassId == classId).ToList();
        }

        //get student by name or surname
        public List<Student> GetStudentsByName(string name)
        {
            return _students.Where(s => s.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) || s.LastName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
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

            JsonDataStore.SaveData(_filePath, _students);
        }

        //delete student by id
        public void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                _students.Remove(student);
                JsonDataStore.SaveData(_filePath, _students);
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
