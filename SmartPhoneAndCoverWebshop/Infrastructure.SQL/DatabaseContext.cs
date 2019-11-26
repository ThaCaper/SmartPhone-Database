using Microsoft.EntityFrameworkCore;
using SmartPhoneShop.Entity;

namespace Infrastructure.SQL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions opt) : base(opt)
        {
            
        }

       /* protected override void onModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/

       public DbSet<User> Users { get; set; }
       public DbSet<SmartPhone> SmartPhones { get; set; }
       public DbSet<Cover> Covers { get; set; }
       public DbSet<Address> Addresses { get; set; }
       public DbSet<Product> Products { get; set; }
       
    }
}