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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<Teacher> GetTeachersByIdAsync(int id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }
        public async Task<ICollection<Teacher>> GetByNameAsync(string name)
        {
            return await _teacherRepository.GetByNameAsync(name);
        }

        public async Task<ICollection<Teacher>> GetByEmailAsync(string email)
        {
            return await _teacherRepository.GetByEmailAsync(email);
        }

        public async Task<ICollection<Teacher>> GetByDepartemntAsync(string department)
        {
            return await _teacherRepository.GetByDepartemntAsync(department);
        }

        public async Task<ICollection<Teacher>> GetTeachersBySubjectId(int subjectId)
        {
            return await _teacherRepository.GetTeachersBySubjectId(subjectId);
        }

        public async Task<Teacher> CreateAsync(Teacher teacher)
        {
            return await _teacherRepository.CreateAsync(teacher);
        }

        public async Task<Teacher> UpdateAsync(Teacher teacher)
        {
            return await _teacherRepository.UpdateAsync(teacher);
        }

        public async Task<bool> DeleteAsync(int Id)
        {

            var result = await _teacherRepository.DeleteAsync(Id);
            return result;
        }

    }
}
