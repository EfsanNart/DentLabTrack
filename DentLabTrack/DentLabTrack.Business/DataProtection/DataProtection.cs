using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.DataProtection
{
    public class DataProtection : IDataProtection
    {

        //This class is responsible for protecting and unprotecting sensitive data such as passwords.
        //It uses the ASP.NET Core Data Protection library to encrypt and decrypt data.
        private readonly IDataProtector _protector;
        public DataProtection(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("DentLabTrack-security-v1");
        }
        //This method is responsible for protecting sensitive data such as passwords. It uses the ASP.NET Core Data Protection library to encrypt the data.
        public string Protect(string text)
        {
            return _protector.Protect(text);
        }
        // This method is responsible for unprotecting sensitive data such as passwords. It uses the ASP.NET Core Data Protection library to decrypt the data.
        public string Unprotect(string protectedText)
        {
            return _protector.Unprotect(protectedText);
        }
    }
}
