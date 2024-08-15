using System.ComponentModel.DataAnnotations;

namespace TasksEvaluation.Core.CustomValidationAttributes
{
    public class IsDateLaterThanNowAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            if (dateTime <= DateTime.Now)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
        public string GetErrorMessage()
        {
            return $"This Date is not allowed!";
        }
    }
}
