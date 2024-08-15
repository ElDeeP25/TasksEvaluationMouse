using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksEvaluation.Core.Entities.General;

namespace TasksEvaluation.Core.Entities.Business
{
    public class EvaluationGrade : Base
    {
        
        public string Grade { get; set; }
        public ICollection <Solution> Solution { get; set; }
    }
}
