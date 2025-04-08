using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentLabTrack.Data.Entities
{
    //This is the join table for the many-to-many relationship between OrderEntity and LabTechnicianEntity
    public class OrderTechnician :BaseEntity
    {
        
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }

        public int TechnicianId { get; set; }
        public LabTechnicianEntity Technician { get; set; }
    } 
}
