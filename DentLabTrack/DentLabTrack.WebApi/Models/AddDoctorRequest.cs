using System.ComponentModel.DataAnnotations;

namespace DentLabTrack.WebApi.Models
{
    
    // This class is used to receive data from the client when adding a new doctor
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
