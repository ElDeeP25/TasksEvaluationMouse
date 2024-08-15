using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksEvaluation.Core.Entities.General;

namespace TasksEvaluation.Core.Entities.Business
{
    public class Group : Base
    {
        public string Title { get; set; }
        
        public Course Course { get; set; }
        
        public int? CourseId { get; set; }
        
        public ICollection<Student> Students { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
