using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Net;
using System.Net.Mail;
using TasksEvaluation.Infrastructure.Models;

namespace TasksEvaluation.Web.Helper
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            /// 555 port mail server
            ///naser@linkdv.com
            /// 
            var client = new SmtpClient("stemp.gmail.com", 587); 

            //we can use pakage => mailkit : best

           client.EnableSsl = true;
 
           client.Credentials = new NetworkCredential("nassermessileo10@gmail.com", "password");

           client.Send("nassermessileo10@gmail.com", email.To,email.subject,email.body);
        
        
        
        
        }

       // public  Task SendEmailAsync(string email, string subject, string message)
       // {
       //     var mail = "tutorialseu-dev@outlook.com";
       //     var pw = "Test12345678!";
       //     var client = new SmtpClient("stmp=mail.gmail.com,587")
       //     {
       //         EnableSsl = true,
       //         Credentials = new NetworkCredential(mail, pw)
       //     };
       //  //   return client.SendAsync (new MailMessage(from: mail, to: email, subject, message));
       // }
    }
}
