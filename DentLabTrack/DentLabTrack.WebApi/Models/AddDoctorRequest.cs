using System.ComponentModel.DataAnnotations;

namespace DentLabTrack.WebApi.Models
{
    public class AddDoctorRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ClinicName { get; set; }
    }
}
