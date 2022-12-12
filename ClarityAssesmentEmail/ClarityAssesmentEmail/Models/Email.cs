using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClarityAssesmentEmail.Models
{
    public class Email
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The senders address is required please enter it now.")]
        [Display(Name = "From:")]
        [StringLength(50)]
        public string Sender { get; set; } = string.Empty;

        [Required(ErrorMessage = "The senders address is required please enter it now.")]
        [Display(Name = "To:")]
        [StringLength(50)]
        public string Recipient { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Subject:")]
        [StringLength(50)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Body:")]
        public string Body { get; set; } = string.Empty;

        public DateTimeOffset Date { get; set; }


    }


}
