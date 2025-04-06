using DentLabTrack.Business.Operations.Patient.Dtos;
using DentLabTrack.Business.Types;
using DentLabTrack.Data.Entities;
using DentLabTrack.Data.Repositories;
using DentLabTrack.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.Patient
{
    public class PatientManager:IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PatientEntity> _patientRepository;

        public PatientManager(IUnitOfWork unitOfWork, IRepository<PatientEntity> patientRepository)
        {
            _unitOfWork = unitOfWork;
            _patientRepository = patientRepository;
        }

        public async Task<ServiceMessage> AddPatient(AddPatientDto dto)
        {
            var exists = _patientRepository.GetAll(x => x.Email.ToLower() == dto.Email.ToLower()).Any();
            if (exists)
            {
                return new ServiceMessage { IsSucceed = false, Message = "Bu e-posta adresi zaten kullanılıyor." };
            }

            var entity = new PatientEntity
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address
            };

            _patientRepository.Add(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage { IsSucceed = true, Message = "Hasta başarıyla eklendi." };
            }
            catch
            {
                throw new Exception("Hasta eklenirken bir hata oluştu.");
            }
        }

        public async Task<List<GetPatientDto>> GetAllPatients()
        {
            var patients = _patientRepository.GetAll(x => !x.IsDeleted).ToList();

            return patients.Select(p => new GetPatientDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                Address = p.Address
            }).ToList();
        }

        public async Task<ServiceMessage> UpdatePatient(UpdatePatientDto dto)
        {
            var patient = _patientRepository.GetById(dto.Id);
            if (patient == null)
            {
                return new ServiceMessage { IsSucceed = false, Message = "Hasta bulunamadı." };
            }

            patient.FirstName = dto.FirstName;
            patient.LastName = dto.LastName;
            patient.Email = dto.Email;
            patient.PhoneNumber = dto.PhoneNumber;
            patient.Address = dto.Address;

            _patientRepository.Update(patient);

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage { IsSucceed = true, Message = "Hasta başarıyla güncellendi." };
            }
            catch
            {
                throw new Exception("Hasta güncellenirken bir hata oluştu.");
            }
        }

        public async Task<ServiceMessage> DeletePatient(int id)
        {
            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                return new ServiceMessage { IsSucceed = false, Message = "Hasta bulunamadı." };
            }

            _patientRepository.Delete(patient);

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage { IsSucceed = true, Message = "Hasta başarıyla silindi." };
            }
            catch
            {
                throw new Exception("Hasta silinirken bir hata oluştu.");
            }
        }

    }
}
