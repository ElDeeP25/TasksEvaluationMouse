using TasksEvaluation.Core.Entities.Business;

namespace TasksEvaluation.Core.DTOs
{
    public class EvaluationGradeDTO
    {
        public string Grade { get; set; }
        public Solution Solution { get; set; }
        public int Id { get; set; }
    }
}
