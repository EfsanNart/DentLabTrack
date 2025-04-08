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


        //Order status : New, InProgress, Completed, Delivered
        public OrderStatus OrderStatus { get; set; }

        //many-to-many relationship with LabTechnicianEntity : A technician may work on more than one order and an order may be worked on by more than one technician
        public ICollection<OrderTechnician> OrderTechnicians { get; set; } = new List<OrderTechnician>();
      
    }
    
}
