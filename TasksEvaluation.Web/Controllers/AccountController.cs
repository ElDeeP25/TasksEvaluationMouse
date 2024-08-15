 using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using TasksEvaluation.Infrastructure.Models;
using TasksEvaluation.Web.Helper;
using TasksEvaluation.Web.ViewModel;
namespace TasksEvaluation.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> UserManager , SignInManager<IdentityUser> SignInManager)
        {
            _userManager = UserManager;
            _signInManager = SignInManager;
        }

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var user = new IdentityUser()
                {
                    UserName= model.Email.Split('@')[0],
                    Email= model.Email,
                     
                };
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded) {
                    RedirectToAction(nameof(Login));
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError(String.Empty, error.Description);
            
            }
             return View(model);
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid) 
            {
                var USER = await _userManager.FindByEmailAsync(model.Email);
                if (USER is not null)
                {
                    var flag = await _userManager.CheckPasswordAsync(USER, model.Password);
                    if (flag)
                    {
                        await _signInManager.PasswordSignInAsync(USER, model.Password, model.RememberMe, false); // if true lock account if login (password or email) incorrect
                    return RedirectToAction("Index" , "Home");
                    }
                    ModelState.AddModelError(string.Empty, "PassWord is not Valid");
                }
                ModelState.AddModelError(string.Empty, "Email is not Exsited");
            }
            return View(model) ;
        }



        #endregion

        #region forget password
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> SendEmail(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var token = _userManager.GeneratePasswordResetTokenAsync(user); // token valid for this user only one-time
                    var passwordRestlink = Url.Action("ResetPassword","Account", new {email = user.Email, token = token},Request.Scheme);
                    var email = new Email()
                    {
                        subject = "Reset password"
                    ,   To = model.Email,
                        body = passwordRestlink
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CheckYourInbox));
                }
                ModelState.AddModelError(string.Empty,"Email is not Exsited");
            }
            return View();
        }

        public IActionResult CheckYourInbox()
        {
            return View();
        }
        #endregion

        #region Reset Password
        public IActionResult ResetPassword(string email , string token  )
        { 
            TempData["email"] = email;
            TempData["token"] = token;
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                string email = TempData["email"] as string;
                string token = TempData["token"] as string;

                var user = await _userManager.FindByEmailAsync(email);
                var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

                if (result.Succeeded)
                    return RedirectToAction(nameof(Login));

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
             }
            return View(model);

        }

        #endregion


    }
}
