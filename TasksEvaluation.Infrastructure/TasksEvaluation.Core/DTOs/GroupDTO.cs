using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksEvaluation.Core.Entities.Business;

namespace TasksEvaluation.Core.DTOs
{
    public class GroupDTO
    {
        public int? CourseId { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public int Id { get; set; }
        
    }
}
