using EFCodeFirstAssignment1.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstAssignment1.Context
{
    public class CustomerDbContext: DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data source=DESKTOP-QM00SQR;Initial Catalog=EFAssignment1;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
    }
}
