using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.DataProtection
{
    public interface IDataProtection
    {
        //Burada şifreleme ve şifre çözme işlemlerini yapacak olan metotları tanımlıyoruz.
        string Protect(string text);
        string Unprotect(string protectedText);
    }
}
