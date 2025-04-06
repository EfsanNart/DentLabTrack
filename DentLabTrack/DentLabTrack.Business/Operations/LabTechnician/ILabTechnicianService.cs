using DentLabTrack.Business.Operations.LabTechnician.Dtos;
using DentLabTrack.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.LabTechnician
{
    public interface ILabTechnicianService
    {
        Task<ServiceMessage> AddLabTechnician(AddLabTechnicianDto addLabTechnicianDto);
        Task<List<GetLabTechnicianDto>> GetAllTechnicians();
        Task<ServiceMessage> UpdateTechnician(UpdateLabTechnicianDto updateTechnicianDto);
        Task<ServiceMessage> DeleteTechnician(int id);
    }
}
