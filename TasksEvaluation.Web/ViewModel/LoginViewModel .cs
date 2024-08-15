using System.ComponentModel.DataAnnotations;

namespace TasksEvaluation.Web.ViewModel
{
    public class LoginViewModel
    {
         
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

}

