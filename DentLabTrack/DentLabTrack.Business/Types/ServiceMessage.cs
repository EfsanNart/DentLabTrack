using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Types
{
    //This class is used to return messages from the service layer to the controller layer
    public class ServiceMessage
    {
        public string Message { get; set; }
        public bool IsSucceed { get; set; }
    }
    public class ServiceMessage<T> //Generic class to return data with message
    {
        public string Message { get; set; }
        public bool IsSucceed { get; set; }
        public T? Data { get; set; } //Nullable type to allow null values
    }
    
}
