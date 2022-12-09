using System.ComponentModel.DataAnnotations;

namespace ClarityEmailApp.Models
{
    public class Email
    {
        public int Id { get; set; }

   
        public string Sender { get; set; } = string.Empty;


        public string Recipient { get; set; } = string.Empty;

 
        public string Subject { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;

        public DateTimeOffset Date { get; set; }
    }
}
