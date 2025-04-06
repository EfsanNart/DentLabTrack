using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace DentLabTrack.Data.Entities
{
    public class LabTechnicianEntity:BaseEntity
    {

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }


        public ICollection<OrderTechnician> OrderTechnicians { get; set; } = new List<OrderTechnician>();


    }
   
}
