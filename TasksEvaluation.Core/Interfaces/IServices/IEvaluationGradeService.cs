using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksEvaluation.Core.DTOs;

namespace TasksEvaluation.Core.Interfaces.IServices
{
    public interface IEvaluationGradeService
    {
        Task<IEnumerable<EvaluationGradeDTO>> GetEvaluationGrades();
        Task<EvaluationGradeDTO> GetEvaluationGrades(int id);
        Task<EvaluationGradeDTO> Create(EvaluationGradeDTO model);
        Task Update(EvaluationGradeDTO model);
        Task Delete(int id);
    }
}
