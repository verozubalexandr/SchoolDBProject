using SchoolDBProject.Models;

namespace SchoolDBProject.Services
{
    public class ClassService
    {
        private List<Class> _classes;

        public ClassService()
        {
            _classes = new List<Class>();
        }
       
        public void AddClass(Class schoolClass)
        {
            _classes.Add(schoolClass);
        }

        public List<Class> GetAllClasses()
        {
            return _classes;
        }

        public Class GetClassById(int id)
        {
            return _classes.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateClass(int id, Class updatedClass)
        {
            var schoolClass = GetClassById(id);
            if (schoolClass != null)
            {
                schoolClass.Name = updatedClass.Name;
                schoolClass.TeacherId = updatedClass.TeacherId;
                schoolClass.StudentIds = updatedClass.StudentIds;
                schoolClass.SubjectIds = updatedClass.SubjectIds;
            }
        }

        public void DeleteClass(int id)
        {
            var schoolClass = GetClassById(id);
            if (schoolClass != null)
            {
                _classes.Remove(schoolClass);
            }
        }
    }
}
