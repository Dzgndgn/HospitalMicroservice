using Doccure.OrderService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.OrderService.Context
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext( DbContextOptions<OrderDbContext> options) : base(options)
        {
            
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
