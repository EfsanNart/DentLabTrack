using DentLabTrack.Business.Operations.Patient.Dtos;
using DentLabTrack.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.Patient
{
    public interface IPatientService
    {
        // This interface defines the contract for patient management operations.
        // It includes methods for adding a new patient, retrieving all patients, updating a patient's information, and deleting a patient.
        Task<ServiceMessage> AddPatient(AddPatientDto addPatientDto);
        Task<List<GetPatientDto>> GetAllPatients();
        Task<ServiceMessage> UpdatePatient(UpdatePatientDto dto);
        Task<ServiceMessage> DeletePatient(int id);
    }
}
