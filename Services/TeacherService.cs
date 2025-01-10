using SchoolDBProject.Interfaces;
using SchoolDBProject.Models;
using SchoolDBProject.Utils;

namespace SchoolDBProject.Services
{
    public class TeacherService : IIdGenerator
    {
        private readonly string _filePath = "DBFiles/teachers.json";
        private List<Teacher> _teachers;

        //create teachers list
        public TeacherService()
        {
            //_teachers = new List<Teacher>();
            _teachers = JsonDataStore.LoadData<Teacher>(_filePath);
        }

        //add new teacher
        public void AddTeacher(Teacher teacher)
        {
            teacher.Id = GenerateId();
            _teachers.Add(teacher);

            JsonDataStore.SaveData(_filePath, _teachers);
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

        //get teacher by subject id
        public List<Teacher> GetTeachersBySubjectId(int subjectId)
        {
            return _teachers.Where(t => t.SubjectIds.Contains(subjectId)).ToList();
        }

        //get teacher by name or surname
        public List<Teacher> GetTeachersByName(string name)
        {
            return _teachers.Where(t => t.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                         t.LastName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
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

            JsonDataStore.SaveData(_filePath, _teachers);
        }

        //delete teacher by id
        public void DeleteTeacher(int id)
        {
            var teacher = GetTeacherById(id);
            if (teacher != null)
            {
                _teachers.Remove(teacher);
                JsonDataStore.SaveData(_filePath, _teachers);
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
