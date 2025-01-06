using SchoolDBProject.Models;

namespace SchoolDBProject.Services
{
    public class TeacherService
    {
        private List<Teacher> _teachers;

        public TeacherService()
        {
            _teachers = new List<Teacher>();
        }

        public void AddTeacher(Teacher teacher)
        {
            _teachers.Add(teacher);
        }

        public List<Teacher> GetAllTeachers()
        {
            return _teachers;
        }

        public Teacher GetTeacherById(int id)
        {
            return _teachers.FirstOrDefault(t => t.Id == id);
        }

        public void UpdateTeacher(int id, Teacher updatedTeacher)
        {
            var teacher = GetTeacherById(id);
            if (teacher != null)
            {
                teacher.FirstName = updatedTeacher.FirstName;
                teacher.LastName = updatedTeacher.LastName;
            }
        }

        public void DeleteTeacher(int id)
        {
            var teacher = GetTeacherById(id);
            if (teacher != null)
            {
                _teachers.Remove(teacher);
            }
        }
    }
}
