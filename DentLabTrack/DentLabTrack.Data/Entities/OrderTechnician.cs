using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentLabTrack.Data.Entities
{
    public class OrderTechnician :BaseEntity
    {
        //Bu sınıfım ara tablo olarak kullanılır. Order ve LabTechnician tablosu arasındaki ilişkiyi temsil eder.
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }

        public int TechnicianId { get; set; }
        public LabTechnicianEntity Technician { get; set; }
    } 
}
