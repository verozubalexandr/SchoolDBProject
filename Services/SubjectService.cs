using SchoolDBProject.Models;

namespace SchoolDBProject.Services
{
    public class SubjectService
    {
        private List<Subject> _subjects;

        public SubjectService()
        {
            _subjects = new List<Subject>();
        }

        public void AddSubject(Subject subject)
        {
            _subjects.Add(subject);
        }

        public List<Subject> GetAllSubjects()
        {
            return _subjects;
        }

        public Subject GetSubjectById(int id)
        {
            return _subjects.FirstOrDefault(s => s.Id == id);
        }

        public void UpdateSubject(int id, Subject updatedSubject)
        {
            var subject = GetSubjectById(id);
            if (subject != null)
            {
                subject.Name = updatedSubject.Name;
                subject.Code = updatedSubject.Code;
                subject.Description = updatedSubject.Description;
                subject.ClassIds = updatedSubject.ClassIds;
            }
        }

        public void DeleteSubject(int id)
        {
            var subject = GetSubjectById(id);
            if (subject != null)
            {
                _subjects.Remove(subject);
            }
        }
    }
}
