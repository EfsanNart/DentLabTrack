using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.Entities
{
    
    public class SettingEntity:BaseEntity
    {
        //Settings for the application 
        public bool MaintenenceMode { get; set; }
    }
}
