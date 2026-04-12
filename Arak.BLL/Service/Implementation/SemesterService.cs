using Arak.BLL.Service.Abstraction;
using Arak.DAL.Entities;
using Arak.DAL.Repository.Abstraction;
using Arak.DAL.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Implementation
{
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _semesterRepository;
        public SemesterService(ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }

        public async Task<IEnumerable<Semester>> GetAllSemesters()
        {
            return await _semesterRepository.GetAllAsync();
        }

        public async Task<Semester> GetSemestertById(int id)
        {
            return await _semesterRepository.GetByIdAsync(id);
        }

        public async Task<Semester> CreateSemester(Semester semester)
        {
            return await _semesterRepository.CreateAsync(semester);
        }

        public async Task<Semester> UpdateSemester(Semester semester)
        {
            return await _semesterRepository.UpdateAsync(semester);
        }

        public async Task<bool> DeleteSemester(int id)
        {
            return await _semesterRepository.DeleteAsync(id);
        }
    }
}
