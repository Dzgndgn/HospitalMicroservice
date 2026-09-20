using Doccure.QueueService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.QueueService.Context
{
    public class QContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=DoccureQueueDb;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<Queue> Queues { get; set; }
    }
}
