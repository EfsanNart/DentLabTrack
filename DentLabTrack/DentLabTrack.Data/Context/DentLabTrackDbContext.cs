using DentLabTrack.Data.Configurations;
using DentLabTrack.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace DentLabTrack.Data.Context
{
    public class DentLabTrackDbContext:DbContext
    {
        public DentLabTrackDbContext(DbContextOptions<DentLabTrackDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api

            //Burada Entity'lerimizi konfigüre ediyoruz. Örneğin, hangi Entity'nin hangi tabloya karşılık geldiğini, hangi alanların zorunlu olduğunu vesaire ayarlıyoruz.

            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new LabTechnicianConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTechnicianConfiguration());

            
            modelBuilder.Entity<SettingEntity>().HasData(new SettingEntity  //Burada veritabanına başlangıç verisi ekliyoruz 
            {
                Id = 1,
                MaintenenceMode = false,
                
            }); // Bu ayar, bakım modunun kapalı olduğunu gösteriyor. İstek attığımızda bu ayar kontrol edilecek ve eğer bakım modunda değilse istek işlenecek.
                // Eğer bakım modunda ise, istek işlenmeyecek ve kullanıcıya bir hata mesajı dönecek.

            base.OnModelCreating(modelBuilder);


        }
        //Burada Tablolarımızı DbSet olarak tanımlıyoruz. Bu DbSet'ler, veritabanındaki tablolarla etkileşim kurmamızı sağlıyor.
        public DbSet<UserEntity> Users=> Set<UserEntity>();
        public DbSet<LabTechnicianEntity> LabTechnicians => Set<LabTechnicianEntity>();
        public DbSet<DoctorEntity> Doctors => Set<DoctorEntity>();
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<PatientEntity> Patients => Set<PatientEntity>();
        public DbSet<OrderTechnician> OrderTechnicians =>Set<OrderTechnician>();
        public DbSet<SettingEntity> Settings { get; set; }





    }
}
