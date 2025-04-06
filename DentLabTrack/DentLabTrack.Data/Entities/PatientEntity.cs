using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentLabTrack.Data.Entities
{
    public class PatientEntity : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        //Relational Properties
        //Bire çok ilişki: Bir hastanın birden fazla siparişi olabilir
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
   
}
