using Doccure.PatientService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PatientService.Context
{
    public class PContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=DoccurePatientDb;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<Patient> Patients { get; set; }
    }
}
