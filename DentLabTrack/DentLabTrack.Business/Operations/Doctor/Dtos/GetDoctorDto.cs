using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.Doctor.Dtos
{
    public class GetDoctorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClinicName { get; set; }
    }
}
