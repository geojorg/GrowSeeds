using System.ComponentModel.DataAnnotations;

namespace GrowSeeds.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MinLength(6)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
