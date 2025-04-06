using DentLabTrack.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.Entities
{
    public class UserEntity:BaseEntity
    {
        //Bu sınıfımda kullanıcı tablosunu temsil eder kullanıcıların sisteme giriş yapabilmesi için gerekli olan bilgileri içerir.
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        //Burada enum kullanarak kullanıcının rolünü belirliyoruz.
        public UserType UserType { get; set; }

   
    }
}
