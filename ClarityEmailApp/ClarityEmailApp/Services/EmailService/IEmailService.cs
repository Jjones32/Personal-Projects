namespace ClarityEmailApp.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(Email request);
    }
}
