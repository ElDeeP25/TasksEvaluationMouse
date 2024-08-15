using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TasksEvaluation.Core.CustomValidationAttributes;
using TasksEvaluation.Core.Entities.General;

namespace TasksEvaluation.Core.Entities.Business
{
    public class Student : Base
    {
        public string FullName { get; set; }

        [RegularExpression(@"^01[0|1|2|5]{1}[0-9]{8}$", ErrorMessage = "Invalid mobile number.")]
        public string MobileNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [FileAllowedExtensions(".jpg", ".jpeg", ".png", ".gif")]
        public string ProfilePic { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public ICollection<Solution> Solutions { get; set; }
    }
   }

