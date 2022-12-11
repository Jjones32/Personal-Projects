using ClarityEmailApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClarityEmailApp.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(Email request);
        Task<List<Email>> GetAllEmailsAsync();
    }
}
