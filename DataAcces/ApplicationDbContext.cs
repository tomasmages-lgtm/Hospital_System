using Hospital_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_System.DataAcces
{
    public class ApplicationDbContext:DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=Hospital_System;" +
                "Trusted_Connection=true;" +
                "TrustServerCertificate=true;Encrypt=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Specialization>().HasData(
                new Specialization { 
                Id=1,
                name="surgery"
                },
                new Specialization {
                Id=2,
                name="pediatrics"
                },
                new Specialization
                {
                    Id=3,
                    name = "dentistry"
                }
                );
        }
        public DbSet<Doctor> Doctors { set; get; }
        public DbSet<Patient> Patients  { set; get; }

        public DbSet<Specialization> Specializations { set; get; }
        public DbSet<PatientAppointDoctor> PatientAppointments { set; get; }
    }
}
