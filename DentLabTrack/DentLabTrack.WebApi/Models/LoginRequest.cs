using System.ComponentModel.DataAnnotations;

namespace DentLabTrack.WebApi.Models
{
    //This class represents the request model for user login
    public class LoginRequest
    {
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
