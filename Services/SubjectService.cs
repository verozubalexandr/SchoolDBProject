using SchoolDBProject.Models;
using SchoolDBProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDBProject.Services
{
    public class SubjectService
    {
        private readonly string _filePath = "DBFiles/subject.json";
        private List<Subject> _subjects;

        public SubjectService()
        {
            //_subjects = new List<Subject>();
            _subjects = JsonDataStore.LoadData<Subject>(_filePath);
        }

        //add new subject
        public void AddSubject(Subject subject)
        {
            subject.Id = GenerateId();
            _subjects.Add(subject);

            JsonDataStore.SaveData(_filePath, _subjects);
        }

        //get all subjects
        public List<Subject> GetAllSubjects()
        {
            return _subjects;
        }

        //get subject by ID
        public Subject GetSubjectById(int id)
        {
            return _subjects.FirstOrDefault(s => s.Id == id);
        }

        //update an existing subject
        public void UpdateSubject(int id, SubjectDTO subjectDTO)
        {
            var subject = GetSubjectById(id);
            if (subject == null)
            {
                throw new ArgumentException("Subject not found");
            }

            subject.Name = subjectDTO.Name ?? subject.Name;
            subject.Code = subjectDTO.Code ?? subject.Code;
            subject.Description = subjectDTO.Description ?? subject.Description;

            JsonDataStore.SaveData(_filePath, _subjects);
        }

        //delete a subject by ID
        public void DeleteSubject(int id)
        {
            var subject = GetSubjectById(id);
            if (subject != null)
            {
                _subjects.Remove(subject);
                JsonDataStore.SaveData(_filePath, _subjects);
            }
        }

        //id generation method from IIdGenerator interface
        private int GenerateId()
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            return (int)(now % int.MaxValue);
        }
    }
}
