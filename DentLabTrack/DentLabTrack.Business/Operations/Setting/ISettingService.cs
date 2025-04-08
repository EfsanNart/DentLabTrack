using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.Setting
{
    public interface ISettingService
    {
        //This interface defines the contract for setting management operations. It includes methods for toggling maintenance mode and getting the current maintenance state.
        Task ToggleMaintenence();
        bool GetMaintenenceState();
    }
}
