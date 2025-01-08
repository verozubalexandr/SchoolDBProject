using SchoolDBProject.Interfaces;
using SchoolDBProject.Models;

namespace SchoolDBProject.Services
{
    public class TeacherService : IIdGenerator
    {
        private List<Teacher> _teachers;

        //create teachers list
        public TeacherService()
        {
            _teachers = new List<Teacher>();
        }

        //add new teacher
        public void AddTeacher(Teacher teacher)
        {
            teacher.Id = GenerateId();
            _teachers.Add(teacher);
        }

        //get all teachers
        public List<Teacher> GetAllTeachers()
        {
            return _teachers;
        }

        //get teacher by id
        public Teacher GetTeacherById(int id)
        {
            return _teachers.FirstOrDefault(t => t.Id == id);
        }

        //update teacher's info
        public void UpdateTeacher(int id, UpdateTeacherDTO updatedTeacher)
        {
            var teacher = GetTeacherById(id);
            if (teacher == null)
            {
                throw new ArgumentException("Teacher not found");
            }

            teacher.FirstName = updatedTeacher.FirstName ?? teacher.FirstName;
            teacher.LastName = updatedTeacher.LastName ?? teacher.LastName;
            teacher.SubjectIds = updatedTeacher.SubjectIds ?? teacher.SubjectIds;
            if (updatedTeacher.ExperienceYears.HasValue)
            {
                teacher.ExperienceYears = updatedTeacher.ExperienceYears.Value;
            }
            teacher.PhoneNumber = updatedTeacher.PhoneNumber ?? teacher.PhoneNumber;
            teacher.Email = updatedTeacher.Email ?? teacher.Email;
            teacher.Position = updatedTeacher.Position ?? teacher.Position;
            teacher.ClassIds = updatedTeacher.ClassIds ?? teacher.ClassIds;
        }

        //delete teacher by id
        public void DeleteTeacher(int id)
        {
            var teacher = GetTeacherById(id);
            if (teacher != null)
            {
                _teachers.Remove(teacher);
            }
        }

        //id generation method from IIdGenerator
        public int GenerateId()
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            return (int)(now % int.MaxValue);
        }
    }
}
