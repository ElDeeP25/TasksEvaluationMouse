using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TasksEvaluation.Core.CustomValidationAttributes
{
    public class MaxSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxSizeAttribute(int maxFileSize) => _maxFileSize = maxFileSize;
        
        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }
        public string GetErrorMessage() => $"Maximum allowed file size is {_maxFileSize} bytes.";
        
    }
}
