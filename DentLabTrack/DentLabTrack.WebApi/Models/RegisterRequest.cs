using System.ComponentModel.DataAnnotations;

namespace DentLabTrack.WebApi.Models
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
