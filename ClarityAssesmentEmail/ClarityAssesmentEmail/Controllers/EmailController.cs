using Microsoft.AspNetCore.Mvc;
using ClarityEmailApp.Services.EmailService;
using MimeKit;
using MailKit.Net.Smtp;
using ClarityAssesmentEmail.Data;
using ClarityAssesmentEmail.Models;
using ClarityAssesmentEmail.Views.Home;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        [HttpGet("Sent")]
        public async Task<IActionResult> GetAllEmails()
        {
            var emails = await _emailService.GetAllEmailsAsync();
            return Ok(emails);
        }
       

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











/*        public async Task<IActionResult> SendEmail()
        {
            return View(await _context.Emails.ToListAsync());
        }*/