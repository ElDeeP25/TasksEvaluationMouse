using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksEvaluation.Core.DTOs
{
    public class AssignmentDTO
    {
        public DateTime DeadLine { get; set; }
        public int GroupId { get; set; }
        public int Id { get; set; }
    }
}
