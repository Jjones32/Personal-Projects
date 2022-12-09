using ClarityEmailApp.Services;
using Microsoft.AspNetCore.Mvc;
using ClarityEmailApp.Models;
using ClarityEmailApp.Services.EmailService;
using Microsoft.EntityFrameworkCore;
using ClarityEmailApp.Data;
using MimeKit;
using MailKit.Net.Smtp;

namespace ClarityEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly EmailDbContext _context;
        public EmailController(IEmailService emailService, ILogger<EmailController> logger, EmailDbContext context)
        {
   
            _emailService=emailService;
            _context= context;
        }

/*        public IActionResult GetEmailList()
        {
            var eList = _context.Emails.ToList();
            var viewModel = new EmailList();
            return Ok(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Sent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var email = await _context.Emails.FirstOrDefaultAsync(m=> m.Id == id);
            if (email == null)
            {
                return NotFound();
            }
            return Ok(email);
        }
*/
        [HttpPost("Send")]
        public async Task<IActionResult> SendEmail(Email request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(request.Sender));
            email.To.Add(MailboxAddress.Parse(request.Recipient));
            email.Subject= request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text= request.Body }; 
            
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("estevan40@ethereal.email", "p3DArGMUNn5H6HaNGf");
            smtp.Send(email);
            smtp.Disconnect(true);
            

            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return Ok(request);
            }

            _emailService.SendEmail(request);

            return Ok(request);
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