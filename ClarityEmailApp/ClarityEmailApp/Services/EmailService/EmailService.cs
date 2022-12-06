using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using ClarityEmailDLL.Services;

namespace ClarityEmailApp.EmailService
{
    public class EmailService : ClarityEmailDLL.Services.EmailService.IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
      
        public void SendEmail(ClarityEmailDLL.Models.EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));             //("tara.rolfson94@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            //email host setup, port setup
            using var smtp = new SmtpClient();
            smtp.Connect/*(_config.GetSection("EmailHost").Value);*/  ("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);  //("tara.rolfson94@ethereal.email", "DKguHGFRqDudYKxz4c");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
