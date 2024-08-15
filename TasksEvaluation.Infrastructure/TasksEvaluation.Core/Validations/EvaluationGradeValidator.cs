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
    public class EvaluationGradeValidator:AbstractValidator<EvaluationGradeDTO>
    {
        public EvaluationGradeValidator()
        {
            RuleFor(e=>e.Grade).NotNull();
        }
    }
}
