using DentLabTrack.Business.Operations.Doctor.Dtos;
using DentLabTrack.Business.Operations.LabTechnician.Dtos;
using DentLabTrack.Business.Types;
using DentLabTrack.Data.Entities;
using DentLabTrack.Data.Repositories;
using DentLabTrack.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.LabTechnician
{
    public class LabTechnicianManager : ILabTechnicianService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<LabTechnicianEntity> _technicianRepository;

        public LabTechnicianManager(IUnitOfWork unitOfWork, IRepository<LabTechnicianEntity> technicianRepository)
        {
            _unitOfWork = unitOfWork;
            _technicianRepository = technicianRepository;
        }

        public async Task<ServiceMessage> AddLabTechnician(AddLabTechnicianDto dto)
        {
            var hasTechnician = _technicianRepository
                .GetAll(x => x.Email.ToLower() == dto.Email.ToLower())
                .Any();

            if (hasTechnician)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu email adresiyle bir teknisyen zaten kayıtlı."
                };
            }

            var technician = new LabTechnicianEntity
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };

            _technicianRepository.Add(technician);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Teknisyen eklenirken bir hata oluştu.");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Teknisyen başarıyla eklendi."
            };
        }

        public async Task<List<GetLabTechnicianDto>> GetAllTechnicians()
        {
            var technicians = _technicianRepository
                .GetAll(x => !x.IsDeleted)
                .ToList();

            return technicians.Select(t => new GetLabTechnicianDto
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Email = t.Email,
                PhoneNumber = t.PhoneNumber
            }).ToList();
        }
        public async Task<ServiceMessage> UpdateTechnician(UpdateLabTechnicianDto dto)
        {
            var technician = _technicianRepository.GetById(dto.Id);
            if (technician == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Teknisyen bulunamadı."
                };
            }

            technician.FirstName = dto.FirstName;
            technician.LastName = dto.LastName;
            technician.Email = dto.Email;
            technician.PhoneNumber = dto.PhoneNumber;

            _technicianRepository.Update(technician);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Teknisyen güncellenirken bir hata oluştu.");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Teknisyen başarıyla güncellendi."
            };
        }

        public async Task<ServiceMessage> DeleteTechnician(int id)
        {
            var technician = _technicianRepository.GetById(id);
            if (technician == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Teknisyen bulunamadı."
                };
            }

            _technicianRepository.Delete(technician);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Teknisyen silinirken bir hata oluştu.");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Teknisyen başarıyla silindi."
            };
        }
    }
}
