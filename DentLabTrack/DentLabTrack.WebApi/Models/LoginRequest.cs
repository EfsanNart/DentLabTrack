using System.ComponentModel.DataAnnotations;

namespace DentLabTrack.WebApi.Models
{
    public class LoginRequest
    {
        //Bu sınıfım kullanıcıdan giriş bilgilerini almak için kullanılır ayrı bir sınıf tanımlamamın sebebi  kullanıcıdan alınan bilgileri tek bir sınıf altında toplayıp kodun okunabilirliğini artırıyorum
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
