using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Types
{
    //  dönen mesajlarımız hemm bool hem de string içereceği için  generic bir class oluşturduk
    public class ServiceMessage
    {
        public string Message { get; set; }
        public bool IsSucceed { get; set; }
    }
    public class ServiceMessage<T>
    {

        public string Message { get; set; }
        public bool IsSucceed { get; set; }
        public T? Data { get; set; }
    }
    
}
