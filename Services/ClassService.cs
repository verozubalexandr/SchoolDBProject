using SchoolDBProject.Interfaces;
using SchoolDBProject.Models;
using System.Linq;

namespace SchoolDBProject.Services
{
    public class ClassService : IIdGenerator
    {
        private List<Class> _classes;

        public ClassService()
        {
            _classes = new List<Class>();
        }

        // add a new class
        public void AddClass(Class newClass)
        {
            newClass.Id = GenerateId();
            _classes.Add(newClass);
        }

        //get all classes
        public List<Class> GetAllClasses()
        {
            return _classes;
        }

        //get class by ID
        public Class GetClassById(int id)
        {
            return _classes.FirstOrDefault(c => c.Id == id);
        }

        //update class details by ID
        public void UpdateClass(int id, UpdateClassDTO updatedClass)
        {
            var classObj = GetClassById(id);
            if (classObj == null)
            {
                throw new ArgumentException("Class not found");
            }

            classObj.Name = updatedClass.Name ?? classObj.Name;
            classObj.TeacherId = updatedClass.TeacherId ?? classObj.TeacherId;
            classObj.StudentIds = updatedClass.StudentIds ?? classObj.StudentIds;
            classObj.SubjectIds = updatedClass.SubjectIds ?? classObj.SubjectIds;
        }

        //delete class by ID
        public void DeleteClass(int id)
        {
            var classObj = GetClassById(id);
            if (classObj != null)
            {
                _classes.Remove(classObj);
            }
        }

        // generate a unique ID for the class
        public int GenerateId()
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            return (int)(now % int.MaxValue);
        }
    }
}
