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
       
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public PatientEntity Patient { get; set; }
        public DoctorEntity Doctor { get; set; }

        public string TreatmentType { get; set; } 
        public DateTime OrderDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }

   
        public OrderStatus OrderStatus { get; set; }

        public ICollection<OrderTechnician> OrderTechnicians { get; set; } = new List<OrderTechnician>();
      
    }
    
}
