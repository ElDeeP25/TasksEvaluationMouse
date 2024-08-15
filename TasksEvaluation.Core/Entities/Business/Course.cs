using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TasksEvaluation.Core.Entities.General;

namespace TasksEvaluation.Core.Entities.Business
{
    public class Course : Base
    {
        
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
