using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksEvaluation.Core.Entities.Business;

namespace TasksEvaluation.Core.DTOs
{
    public class SolutionDTO
    {
        public int Id { get; set; }
        public string SolutionFile { get; set; }
        public string Notes { get; set; }
        public int? AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }
}
