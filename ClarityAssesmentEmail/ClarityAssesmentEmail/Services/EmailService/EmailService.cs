using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Polly.Retry;
using ClarityAssesmentEmail.Data;
using ClarityAssesmentEmail.Models;
using Steeltoe.Common.Retry;

namespace ClarityEmailApp.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly EmailDbContext _context;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _asyncRetryPolicy;
        private readonly ILogger _logger;


        public EmailService(IConfiguration config, EmailDbContext context, ILogger<EmailDbContext> logger)
        {
            _config = config;
            _context = context;
            _logger = logger;

        }

        public async Task<List<Email>> GetAllEmailsAsync()
        {
            var allEmails = await _context.Emails.Select(x => new Email()
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

        public async void SendEmail(Email request)
        {
            var tries = 1;
            while (tries <= 3)
            {
                try
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
                catch
                {
                    tries++;
                }
            }
            throw new RetryException($"Email Could not send after {tries} attempts");

        }

    }
}

