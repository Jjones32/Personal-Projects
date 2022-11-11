using System.ComponentModel.DataAnnotations;

namespace Finesstro_sBeansCoffeeShop.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Custom ErrorMessage")]
        [Display(Name = "Aardvark")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Are you a premium member?")]
        public bool IsPremiumMember { get; set; }
    }
}
