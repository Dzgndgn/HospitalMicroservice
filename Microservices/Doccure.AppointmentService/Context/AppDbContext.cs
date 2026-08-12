using Doccure.AppointmentService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.AppointmentService.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
            "Server=localhost;Database=DoccureAppointmentDb;Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Appointment>()
            .HasOne(x => x.AppointmentDetail).WithOne(x => x.Appointment)
            .HasForeignKey<AppointmentDetail>(x => x.AppointmentId);
            modelBuilder.Entity<DoctorSchedule>().HasMany(x => x.Appointments).WithOne(x => x.DoctorSchedules);
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
    }
}
