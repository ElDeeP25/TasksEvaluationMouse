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
    public class StudentValidator:AbstractValidator<StudentDTO>
    {
        public StudentValidator()
        {
            RuleFor(s=>s.Email).NotNull().EmailAddress();
            RuleFor(s => s.ProfilePic).NotNull().NotEmpty();
            RuleFor(s => s.FullName).NotNull().MaximumLength(30);
            RuleFor(s => s.GroupId).Null();
            RuleFor(s => s.MobileNumber).NotEmpty().WithMessage("Mobile number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid mobile number format.").MaximumLength(11);

        }
    }
}
