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
            // Apply configurations for each entity

            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new LabTechnicianConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTechnicianConfiguration());

            // Seed initial data for the Settings table
            modelBuilder.Entity<SettingEntity>().HasData(new SettingEntity 
            {
                Id = 1,
                MaintenenceMode = false,
                
            }); 

            base.OnModelCreating(modelBuilder);


        }

        //Create a DbSet for each entity
        public DbSet<UserEntity> Users=> Set<UserEntity>();
        public DbSet<LabTechnicianEntity> LabTechnicians => Set<LabTechnicianEntity>();
        public DbSet<DoctorEntity> Doctors => Set<DoctorEntity>();
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<PatientEntity> Patients => Set<PatientEntity>();
        public DbSet<OrderTechnician> OrderTechnicians =>Set<OrderTechnician>();
        public DbSet<SettingEntity> Settings { get; set; }





    }
}
