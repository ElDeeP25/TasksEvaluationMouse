using FluentValidation;
using TasksEvaluation.Core.DTOs;
using TasksEvaluation.Core.Entities.Business;


namespace TasksEvaluation.Core.Validations
{
    public class AssignmentValidator:AbstractValidator<AssignmentDTO>
    {
        public AssignmentValidator()
        {
            
            RuleFor(m => m.DeadLine)
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Datetime must be in the future");
            RuleFor(m=>m.GroupId).Null().WithMessage("GroupId is required.");
        }
    }
}
