using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace ClarityEmailApp.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
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
