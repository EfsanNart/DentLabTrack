﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.Entities
{
    public class DoctorEntity:BaseEntity
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClinicName { get; set; }

    
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

    }
}
