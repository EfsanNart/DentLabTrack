using DentLabTrack.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.Entities
{
    public class OrderEntity:BaseEntity
    {
        //Bu sınıfımda sipariş tablosunu temsil eder. Sipariş tablosu, hastalar ve doktorlar arasındaki ilişkiyi temsil eder.
        //Aynı zamanda LabTechnician tablosuyla da  çoka çok ilişkilidir
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public PatientEntity Patient { get; set; }
        public DoctorEntity Doctor { get; set; }

        public string TreatmentType { get; set; } // Protez, Dolgu, İmplant vb.
        public DateTime OrderDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }

        //Burada enum kullanarak siparişin durumunu belirliyoruz.
        // Siparişin durumu (Yeni, Tamamlandı, İptal Edildi vb.)
        public OrderStatus OrderStatus { get; set; }

        // Çoka-Çok İlişki: Bir sipariş birden fazla teknisyene atanabilir
        public ICollection<OrderTechnician> OrderTechnicians { get; set; } = new List<OrderTechnician>();
      
    }
    
}
