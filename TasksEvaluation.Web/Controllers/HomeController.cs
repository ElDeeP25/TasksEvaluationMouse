using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TasksEvaluation.Web.Helper;
using TasksEvaluation.Web.Models;

namespace TasksEvaluation.Web.Controllers
{
    public class HomeController : Controller
        
    {
        private readonly IEmailSender _emailSender;

       // private readonly ILogger<HomeController> _logger;

        public HomeController(IEmailSender emailSender)
        {
           this._emailSender = emailSender; 
        }
        public async Task<IActionResult> Index()
        {
          //  var reciever = "cilark201@qumax.com";
          //  var subject = "Tset";
          //  var message = "Hello world";
          //  await _emailSender.SendEmailAsync(reciever, subject, message);
            return View();
        }
       
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}