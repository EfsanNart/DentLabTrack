using DentLabTrack.Data.Entities;
using DentLabTrack.Data.Repositories;
using DentLabTrack.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.Setting
{
    public class SettingManager : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<SettingEntity> _settingRepository;

        public SettingManager(IUnitOfWork unitOfWork, IRepository<SettingEntity> settingRepository)
        {
            _unitOfWork = unitOfWork;
            _settingRepository = settingRepository;
        }

        public bool GetMaintenenceState()
        {
            var maintenenceState = _settingRepository.GetById(1).MaintenenceMode;
            return maintenenceState;
        }

        public async Task ToggleMaintenence()
        {
            var setting = _settingRepository.GetById(1);

            setting.MaintenenceMode = !setting.MaintenenceMode;
            _settingRepository.Update(setting);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Bakım durumu güncellenirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}

