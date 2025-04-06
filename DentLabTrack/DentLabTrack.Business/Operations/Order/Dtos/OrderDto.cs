using DentLabTrack.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.Order.Dtos
{
    public class OrderDto
    {

        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string TreatmentType { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public List<OrderTechnicianDto> Technicians { get; set; }
    }
}
