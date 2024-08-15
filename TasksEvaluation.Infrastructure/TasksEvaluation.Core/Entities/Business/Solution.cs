using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksEvaluation.Core.CustomValidationAttributes;
using TasksEvaluation.Core.Entities.General;

namespace TasksEvaluation.Core.Entities.Business
{
    public class Solution : Base
    {
        [FileAllowedExtensions(".docx", "..pdf", ".txt", ".rar", ".docx", ".rar")]
        public string SolutionFile { get; set; }
        public string Notes { get; set; }
        
        public int? AssignmentId { get; set; }
        public int? GradeId { get; set; }
        public int? StudentId { get; set; }
        public Assignment Assignment { get; set; }
        public Student Student { get; set; }
        public EvaluationGrade Grade { get; set; }

    }

   

}
