using Microsoft.EntityFrameworkCore;
using SmartPhoneShop.Entity;

namespace Infrastructure.SQL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions opt) : base(opt)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasKey(p => new {p.Id});

            modelBuilder.Entity<Order>()
                .HasOne(u => u.User)
                .WithMany(us => us.ListOfOrders)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OrderLine>()
                .HasKey(ol => new {ol.ProductId, ol.OrderId});

            modelBuilder.Entity<OrderLine>()
                .HasOne(ca => ca.Order)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(ca => ca.OrderId);

            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Product)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(ol => ol.ProductId);

            modelBuilder.Entity<User>()
                .HasKey(u => new {u.Id});
        }

       public DbSet<User> Users { get; set; }
       public DbSet<SmartPhone> SmartPhones { get; set; }
       public DbSet<Cover> Covers { get; set; }
       public DbSet<Product> Products { get; set; }
       public DbSet<Order> Orders { get; set; } 
       public DbSet<OrderLine> OrderLines { get; set; }
    }
}