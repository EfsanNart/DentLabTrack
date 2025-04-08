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

        //Relational properties
        //One-to-many relationship with OrderEntity : A patient may have more than one order
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
   
}
