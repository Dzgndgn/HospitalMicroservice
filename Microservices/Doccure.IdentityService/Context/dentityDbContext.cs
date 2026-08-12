using Doccure.IdentityService.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Doccure.IdentityService.Context
{
    public class dentityDbContext : IdentityDbContext<AppUser>
    {
        public dentityDbContext(
        DbContextOptions<dentityDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=DoccureIdentityDb;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
