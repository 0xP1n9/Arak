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
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _EvaluationRepository;

        public EvaluationService(IEvaluationRepository EvaluationRepository)
        {
            _EvaluationRepository = EvaluationRepository;
        }

        public async Task<Evaluation> CreateEvaluation(Evaluation evaluation)
        {
            return await _EvaluationRepository.CreateAsync(evaluation);
        }

        public async Task<IEnumerable<Evaluation>> GetAllEvaluations()
        {
            return await _EvaluationRepository.GetAllAsync();
        }

        public async Task<Evaluation> GetEvaluationById(int id)
        {
            return await _EvaluationRepository.GetByIdAsync(id);
        }

        public async Task<bool> DeleteEvaluation(int id)
        {
            return await _EvaluationRepository.DeleteAsync(id);
        }

        public async Task<Evaluation> UpdateEvaluation(Evaluation evaluation)
        {
            return await _EvaluationRepository.UpdateAsync(evaluation);
        }

        public async Task<ICollection<Evaluation>> GetEvaluationsByStudentId(int studentId)
        {
            var all = await _EvaluationRepository.GetAllAsync();
            return all.Where(x => x.StudentId == studentId).ToList();
        }
    }
}
