using DentLabTrack.Business.Operations.Doctor.Dtos;
using DentLabTrack.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.Doctor
{
    public interface IDoctorService
    {
        Task<ServiceMessage> AddDoctor(AddDoctorDto addDoctorDto);
        Task<ServiceMessage> UpdateDoctor(UpdateDoctorDto updateDoctorDto);
        Task<ServiceMessage> DeleteDoctor(int id);
        Task<List<GetDoctorDto>> GetAllDoctors();



    }
}
