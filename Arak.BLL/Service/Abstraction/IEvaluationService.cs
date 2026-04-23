using Arak.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Abstraction
{
    public interface IEvaluationService
    {
        Task<IEnumerable<Evaluation>> GetAllEvaluations();
        Task<Evaluation> GetEvaluationById(int id);
        Task<ICollection<Evaluation>> GetEvaluationsByStudentId(int studentId);

        Task<Evaluation> CreateEvaluation(Evaluation evaluation);
        Task<Evaluation> UpdateEvaluation(Evaluation evaluation);

        Task<bool> DeleteEvaluation(int id);
    }
}

