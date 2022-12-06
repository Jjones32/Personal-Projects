using ClarityEmailDLL.Services;
using Microsoft.AspNetCore.Mvc;
using ClarityEmailDLL.Models;


namespace ClarityEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ClarityEmailDLL.Services.EmailService.IEmailService _emailService;

        public EmailController(ClarityEmailDLL.Services.EmailService.IEmailService emailService)
        {
            _emailService= emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request: request);

            return Ok();
        }
    }
}




//• Code should be written in C#. 

//• Send Email Method should be in a dll that can be reused throughout different applications and entry  points. 

//• Email =**sender**=, =**recipient**=, =**subject**=, and =**body (not attachments)**=, and =**date**= must be logged/stored indefinitely  with status of send attempt. 

//• If email fails to send it should either be retried until success or a max of 3 times whichever comes first, and can be sent in succession or over a period of time. 

//• Please store all credentials in an appsettings instead of hardcoded. 

//• At minimum that method/dll should be called from a console application. 

//• Extra Credit if attached to an API that can be called from Postman. 
//• EXTRA Credit if a front end (wpf/asp.net web application/etc…) calls the API to send the email.

//• In any scenario you should be able to take in an input of a recipient email to send a test email.