using System.ComponentModel.DataAnnotations;

namespace TasksEvaluation.Web.ViewModel
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } 
    }
}
