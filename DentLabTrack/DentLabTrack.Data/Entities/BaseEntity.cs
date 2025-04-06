using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

    }
    
    //Projemde, dental laboratuvar süreçlerini yöneten bir sistem geliştirdim. Özellikle Entity yapısını oluştururken, sipariş ve teknisyenler arasında çoka-çok ilişkileri dikkatle tasarladım.
    //Sipariş ekleme sırasında aynı anda birden fazla teknisyeni sisteme dahil ediyorum ve bu işlemi transactional bir yapı ile güvenli hale getiriyorum.
    //Bu sayede işlemler ya tamamen başarılı oluyor ya da hiç yapılmamış gibi geri alınıyor.
    //Veri yönetiminde soft delete mantığını tercih ettim; böylece silinen veriler fiziksel olarak kaybolmuyor
    //Bu hem güvenli bir yapı sağlıyor hem de yönetimsel açıdan esneklik sunuyor.
    //Servis katmanında UnitOfWork ve Repository Pattern kullanarak kodun test edilebilirliğini ve sürdürülebilirliğini artırdım. 
    //Controller katmanında ise JWT tabanlı kimlik doğrulama sistemi kurdum ve kullanıcı rollerine göre erişim kısıtlamaları getirdim.
    //Bu yapılar sayesinde hem güvenli hem de ölçeklenebilir bir sistem ortaya koymuş oldum.

    // 1. Kat: Data katmanı (Entity, DbContext, Repository) bu katmanda veritabanı ile ilgili işlemler yapılır.
    // 2. Kat: Service katmanı (Service, DTO) bu katmanda iş mantığı ve veri transferi işlemleri yapılır.
    // 3. Kat: Web katmanı (Controller, Model) bu katmanda  kullanıcı etkileşimleri yapılır.

}
