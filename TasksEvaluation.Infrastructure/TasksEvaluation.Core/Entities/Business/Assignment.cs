using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TasksEvaluation.Core.Entities.General;

namespace TasksEvaluation.Core.Entities.Business
{
    public class Assignment : Base
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }      
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public ICollection<Solution> Solutions{ get; set; }
    }
}
