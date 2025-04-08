using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace DentLabTrack.Data.Entities
{
    public class LabTechnicianEntity:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        //Relational properties
        //Many-to-many relationship with OrderEntity : A technician may work on more than one order and an order may be worked on by more than one technician
        public ICollection<OrderTechnician> OrderTechnicians { get; set; } = new List<OrderTechnician>();


    }
   
}
