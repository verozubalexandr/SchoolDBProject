using SchoolDBProject.Models;
using SchoolDBProject.Interfaces;
using System.Linq;

namespace SchoolDBProject.Services
{
    public class ParentService : IIdGenerator
    {
        private List<Parent> _parents;

        //create parents list
        public ParentService()
        {
            _parents = new List<Parent>();
        }

        //add new parent
        public void AddParent(Parent parent)
        {
            parent.Id = GenerateId();
            _parents.Add(parent);
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
        }

        //delete parent by id
        public void DeleteParent(int id)
        {
            var parent = GetParentById(id);
            if (parent != null)
            {
                _parents.Remove(parent);
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
