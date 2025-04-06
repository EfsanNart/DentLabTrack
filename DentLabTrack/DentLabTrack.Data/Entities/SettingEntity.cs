using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.Entities
{
    public class SettingEntity:BaseEntity
    {
        //Burada uygulama ayarlarını tutacağım. Örneğin uygulamanın bakımda olup olmadığını burada tutacağım.
        public bool MaintenenceMode { get; set; }
    }
}
