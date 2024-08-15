using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksEvaluation.Core.DTOs;
using TasksEvaluation.Core.Entities;
using TasksEvaluation.Core.Entities.Business;

namespace TasksEvaluation.Core.Validations
{
    public class SolutionValidator : AbstractValidator<SolutionDTO>
    {
        public SolutionValidator()
        {
            RuleFor(s => s.SolutionFile).NotNull().Must(EndsWithEx);
            RuleFor(s => s.Notes).NotNull().NotEmpty();            
            RuleFor(s => s.AssignmentId).Null();

        }
        private bool EndsWithEx(string solutionFile)
        {
            var extension = new List<string> { ".png", ".jpg", ".jpeg", ".zip", ".pdf", ".img" };
            string fileExtension = Path.GetExtension(solutionFile);
            return extension.Contains(fileExtension, StringComparer.OrdinalIgnoreCase);
        }
    }
}
