using SchoolDBProject.Interfaces;
using SchoolDBProject.Models;
using SchoolDBProject.Utils;
using System.Linq;

namespace SchoolDBProject.Services
{
    public class ClassService : IIdGenerator
    {
        private readonly string _filePath = "DBFiles/classes.json";
        private List<Class> _classes;

        public ClassService()
        {
            //_classes = new List<Class>();
            _classes = JsonDataStore.LoadData<Class>(_filePath);
        }

        // add a new class
        public void AddClass(Class newClass)
        {
            newClass.Id = GenerateId();
            _classes.Add(newClass);

            JsonDataStore.SaveData(_filePath, _classes);
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

            JsonDataStore.SaveData(_filePath, _classes);
        }

        //delete class by ID
        public void DeleteClass(int id)
        {
            var classObj = GetClassById(id);
            if (classObj != null)
            {
                _classes.Remove(classObj);
                JsonDataStore.SaveData(_filePath, _classes);
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
