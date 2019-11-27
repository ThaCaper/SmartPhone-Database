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

            modelBuilder.Entity<SmartPhone>()
                .OwnsOne(p => p.ProductType);

            modelBuilder.Entity<SmartPhone>()
                .HasKey(sp => new {sp.Id});

            modelBuilder.Entity<Cover>()
                .OwnsOne(p => p.ProductType);

            modelBuilder.Entity<Cover>()
                .HasKey(c => new {c.Id});

            modelBuilder.Entity<Order>()
                .HasOne(u => u.User)
                .WithMany(us => us.ListOfOrders)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OrderLine>()
                .HasKey(ca => new {ca.OrderId, ca.ProductId});

            modelBuilder.Entity<OrderLine>()
                .HasOne(ca => ca.Order)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(ca => ca.OrderId);

            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.SmartPhone.ProductType)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(ol => ol.ProductId);
            
            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Cover.ProductType)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(ol => ol.ProductId);
        }

       public DbSet<User> Users { get; set; }
       public DbSet<SmartPhone> SmartPhones { get; set; }
       public DbSet<Cover> Covers { get; set; }
       public DbSet<Address> Addresses { get; set; }
       public DbSet<Product> Products { get; set; }
       public DbSet<ShoppingCart> Carts { get; set; }
       public DbSet<Order> Orders { get; set; } 
       public DbSet<OrderLine> OrderLines { get; set; }
    }
}