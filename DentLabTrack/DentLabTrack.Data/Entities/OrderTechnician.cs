using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentLabTrack.Data.Entities
{
    public class OrderTechnician :BaseEntity
    {
        
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }

        public int TechnicianId { get; set; }
        public LabTechnicianEntity Technician { get; set; }
    } 
}
