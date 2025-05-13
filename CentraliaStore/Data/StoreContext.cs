using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CentraliaStore.Models;

namespace CentraliaStore.Data
{
    public class StoreContext : IdentityDbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }
        public DbSet<CentraliaStore.Models.Role> Role { get; set; } = default!;
    }
}
