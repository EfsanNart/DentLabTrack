using DentLabTrack.Business.Operations.Doctor.Dtos;
using DentLabTrack.Business.Types;
using DentLabTrack.Data.Repositories;
using DentLabTrack.Data.UnitOfWork;
using DentLabTrack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.Doctor
{
    public class DoctorManager : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<DoctorEntity> _doctorRepository;
        private readonly IRepository<OrderEntity> _orderRepository;
        public DoctorManager(IUnitOfWork unitOfWork, IRepository<DoctorEntity> doctorRepository)
        {
            _unitOfWork = unitOfWork;
            _doctorRepository = doctorRepository;
        }
        public async Task<ServiceMessage> AddDoctor(AddDoctorDto addDoctorDto)
        {
            var hasDoctor = _doctorRepository.GetAll(x => x.ClinicName.ToLower() == addDoctorDto.ClinicName.ToLower()).Any();
            if (hasDoctor)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu klinik adı zaten mevcut"
                };
            }
            var doctorEntity = new DoctorEntity
            {
                ClinicName = addDoctorDto.ClinicName,
                FirstName = addDoctorDto.FirstName,
                LastName = addDoctorDto.LastName,
            };
            _doctorRepository.Add(doctorEntity);
            try
            {
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new Exception("Doktor kaydedilirken bir hata oluştu");
            }
            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Doktor başarıyla kaydedildi"
            };
        }


        
        public async Task<ServiceMessage> DeleteDoctor(int id)
        {
            var patient = _doctorRepository.GetById(id);
            if (patient == null)
            {
                return new ServiceMessage { IsSucceed = false, Message = "Doktor bulunamadı." };
            }

            _doctorRepository.Delete(patient);

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage { IsSucceed = true, Message = "Doktor başarıyla silindi." };
            }
            catch
            {
                throw new Exception("Doktor silinirken bir hata oluştu.");
            }
        }

        public async Task<ServiceMessage> UpdateDoctor(UpdateDoctorDto updateDoctorDto)
        {

            var doctor = _doctorRepository.GetById(updateDoctorDto.Id);
            if (doctor == null)
            {
                return new ServiceMessage { IsSucceed = false, Message = "Doktor bulunamadı" };
            }

            doctor.FirstName = updateDoctorDto.FirstName;
            doctor.LastName = updateDoctorDto.LastName;
            doctor.ClinicName = updateDoctorDto.ClinicName;

            _doctorRepository.Update(doctor);
            try
            {
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new Exception("Doktor Güncellenirken bir hata oluştu");
            }
            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Doktor başarıyla güncellendi"
            };

        }
        public async Task<List<GetDoctorDto>> GetAllDoctors()
        {
            var doctors = _doctorRepository
                            .GetAll(x => !x.IsDeleted)
                            .ToList();

            var doctorDtos = doctors.Select(x => new GetDoctorDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                ClinicName = x.ClinicName
            }).ToList();

            return doctorDtos;
        }
    }
}