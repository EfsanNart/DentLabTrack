using System.ComponentModel.DataAnnotations;

namespace DentLabTrack.WebApi.Models
{
    
    //This class is used to create a new order
    public class AddOrderRequest
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string TreatmentType { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public List<int> TechnicianIds { get; set; }
    }
}
