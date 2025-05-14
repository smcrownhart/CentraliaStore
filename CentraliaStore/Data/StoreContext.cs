using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CentraliaStore.Models;
using CentraliaStore.Areas.Identity;

namespace CentraliaStore.Data
{
    public class StoreContext : IdentityDbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        // dynamic seeded data and configuration goes here
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        // static seeded data and model setup goes in this method
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // add categories
            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Sweatshirts" },
                new Category { CategoryId = 2, Name = "Water Bottles" },
                new Category { CategoryId = 3, Name = "Notebooks" },
                new Category { CategoryId = 4, Name = "Textbooks" }
            );
        }

        public DbSet<Role> Role { get; set; } = default!;
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<AppUser> Users { get; set; }
    }
}
