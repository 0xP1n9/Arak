using Arak.BLL.Service.Abstraction;
using Arak.DAL.Entities;
using Arak.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Implementation
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            return await _subjectRepository.GetAllAsync();
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            return await _subjectRepository.GetByIdAsync(id);
        }

        public async Task<Subject> CreateSubject(Subject subject)
        {
            return await _subjectRepository.CreateAsync(subject);
        }

        public async Task<Subject> UpdateSubject(Subject subject)
        {
            return await _subjectRepository.UpdateAsync(subject);
        }

        public async Task<bool> DeleteSubject(int id)
        {
            return await _subjectRepository.DeleteAsync(id);
        }
    }
}
