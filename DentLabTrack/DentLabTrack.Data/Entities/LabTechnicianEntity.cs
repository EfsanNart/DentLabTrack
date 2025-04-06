using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace DentLabTrack.Data.Entities
{
    public class LabTechnicianEntity:BaseEntity
    {
        //Bu sınıfım ordertechnician tablosuyla ilişkilidir. OrderTechnician tablosu, sipariş ve teknisyen arasındaki ilişkiyi temsil eder.
        //Yani bir siparişin birden fazla teknisyeni olabilir ve bir teknisyenin de birden fazla siparişi olabilir.
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }


        //Çoka-Çok İlişki: Bir teknisyen birden fazla siparişte çalışabilir
        public ICollection<OrderTechnician> OrderTechnicians { get; set; } = new List<OrderTechnician>();


    }
   
}
