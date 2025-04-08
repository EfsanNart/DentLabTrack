using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.DataProtection
{
    public interface IDataProtection
    {
        //This interface defines the contract for data protection operations. It includes methods for protecting and unprotecting data.
        string Protect(string text);
        string Unprotect(string protectedText);
    }
}
