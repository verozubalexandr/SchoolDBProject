using SchoolDBProject.Models;
using SchoolDBProject.Interfaces;
using System.Linq;
using SchoolDBProject.Utils;

namespace SchoolDBProject.Services
{
    public class ParentService : IIdGenerator
    {
        private readonly string _filePath = "DBFiles/parents.json";
        private List<Parent> _parents;

        //create parents list
        public ParentService()
        {
            //_parents = new List<Parent>();
            _parents = JsonDataStore.LoadData<Parent>(_filePath);
        }

        //add new parent
        public void AddParent(Parent parent)
        {
            parent.Id = GenerateId();
            _parents.Add(parent);

            JsonDataStore.SaveData(_filePath, _parents);
        }

        //get all parents
        public List<Parent> GetAllParents()
        {
            return _parents;
        }

        //get parent by id
        public Parent GetParentById(int id)
        {
            return _parents.FirstOrDefault(p => p.Id == id);
        }

        //get parents by child id
        public List<Parent> GetParentsByChildId(int childId)
        {
            return _parents.Where(p => p.ChildIds.Contains(childId)).ToList();
        }

        //get parents by name
        public List<Parent> GetParentsByName(string name)
        {
            return _parents.Where(p => p.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) || p.LastName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        //update student's info
        public void UpdateParent(int id, UpdateParentDTO updatedParent)
        {
            var parent = GetParentById(id);
            if (parent == null)
            {
                throw new ArgumentException("Parent not found");
            }

            parent.FirstName = updatedParent.FirstName ?? parent.FirstName;
            parent.LastName = updatedParent.LastName ?? parent.LastName;
            parent.PhoneNumber = updatedParent.PhoneNumber ?? parent.PhoneNumber;
            parent.Email = updatedParent.Email ?? parent.Email;
            parent.ChildIds = updatedParent.ChildIds ?? parent.ChildIds;

            JsonDataStore.SaveData(_filePath, _parents);
        }

        //delete parent by id
        public void DeleteParent(int id)
        {
            var parent = GetParentById(id);
            if (parent != null)
            {
                _parents.Remove(parent);
                JsonDataStore.SaveData(_filePath, _parents);
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
