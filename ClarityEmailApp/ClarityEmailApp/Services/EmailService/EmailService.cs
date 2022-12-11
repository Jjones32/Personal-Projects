using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using ClarityEmailApp.Data;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using ClarityEmailApp.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ClarityEmailApp.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly EmailDbContext _context;
        public EmailService(IConfiguration config, EmailDbContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task<List<Email>> GetAllEmailsAsync()
        {
            var allEmails = await _context.Emails.Select(x=> new Email()
            {
                Id= x.Id,
                Sender= x.Sender,
                Recipient= x.Recipient,
                Subject= x.Subject, 
                Body= x.Body,
                Date= x.Date
            }).ToListAsync();

            return allEmails;
        }

        public void SendEmail(Email request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("estevan40@ethereal.email"));                                               //(_config.GetSection("EmailUsername").Value))
            email.To.Add(MailboxAddress.Parse(request.Recipient));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            //email host setup, port setup
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);                                          //(_config.GetSection("EmailHost").Value
            smtp.Authenticate("estevan40@ethereal.email", "DKguHGFRqDudYKxz4c");                        //("EmailUsername").Value, _config.GetSection("EmailPassword").Value); 
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
