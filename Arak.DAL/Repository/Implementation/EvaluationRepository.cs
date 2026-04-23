using Arak.DAL.Database;
using Arak.DAL.Entities;
using Arak.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.DAL.Repository.Implementation
{
    public class EvaluationRepository : GenericRepository<Evaluation>, IEvaluationRepository
    {
        public EvaluationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
