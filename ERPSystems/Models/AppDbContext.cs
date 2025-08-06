using Microsoft.EntityFrameworkCore;

namespace WMSSystems.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        // Add other DbSet<T> properties for other models as needed
    }
}       