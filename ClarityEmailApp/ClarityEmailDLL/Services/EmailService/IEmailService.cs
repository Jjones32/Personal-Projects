using ClarityEmailDLL.Models;

namespace ClarityEmailDLL.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
