using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectShopping.Entities;

namespace ProjectShopping.DbContexts
{
    public class ShopingDbContext : DbContext
    {
        public ShopingDbContext(DbContextOptions<ShopingDbContext> options) : base(options)
        {

        }
        public DbSet<Product> products { set; get; }
        public DbSet<Tags> AllTags{ get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Stock> stocks { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Cart> carts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Tags>()
                .HasKey(t => new { t.PID, t.tag });
            modelBuilder.Entity<Stock>()
                .HasKey(s => new {s.PID, s.color ,s.size});
            modelBuilder.Entity<Product>().HasData(
                    new Product()
                    {
                        PID = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                        Name = "abcd",
                        Price = 20,
                        Description = "aasdf as dfgaskjdf askdfh askjdfh lasdf",
                        Gender = "Men",
                        MainCategory = "Shirt"
                    }
                );
            modelBuilder.Entity<Tags>().HasData(
                    new Tags()
                    {
                        PID = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                        tag = "cotton"
                        
                    },
                    new Tags()
                    {
                        PID = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                        tag = "Full-sleves"

                    }
                );
        }

    }
}
