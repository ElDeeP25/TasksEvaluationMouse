using System.ComponentModel.DataAnnotations;

namespace TasksEvaluation.Core.CustomValidationAttributes
{
    public class FileAllowedExtensions : ValidationAttribute
    {
        private readonly string[] _extensions;

        public FileAllowedExtensions(params string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not null)
            {
                var fileExtension = Path.GetExtension(value.ToString()).ToLower();
                if (!_extensions.Contains(fileExtension))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Only files with the following extensions are allowed: {string.Join(", ", _extensions)}";
        }


    }
}
