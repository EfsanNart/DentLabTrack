using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.Doctor.Dtos
{
    public class DoctorOrderDto
    {
        public int OrderId { get; set; }
        public string TreatmentType { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public string OrderStatus { get; set; }
        public string PatientFullName { get; set; }
    }
}
