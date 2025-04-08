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
        //This interface defines the contract for lab technician management operations.
        //It includes methods for adding, updating, deleting, and retrieving lab technicians.
        Task<ServiceMessage> AddLabTechnician(AddLabTechnicianDto addLabTechnicianDto);
        Task<List<GetLabTechnicianDto>> GetAllTechnicians();
        Task<ServiceMessage> UpdateTechnician(UpdateLabTechnicianDto updateTechnicianDto);
        Task<ServiceMessage> DeleteTechnician(int id);
    }
}
