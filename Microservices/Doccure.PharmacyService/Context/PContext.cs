using Doccure.PharmacyService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PharmacyService.Context
{
    public class PContext : DbContext
    {
        public PContext(DbContextOptions<PContext> options) : base(options)
        {
            
        }
        public DbSet<Medicine> Medicines { get; set; }
    }
}
