﻿using System.ComponentModel.DataAnnotations;

namespace DentLabTrack.WebApi.Models
{
    public class UpdateLabTechnicianRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
