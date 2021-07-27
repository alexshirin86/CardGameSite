using Microsoft.EntityFrameworkCore;
using CardGameSite.DAL.Entities;

namespace CardGameSite.DAL.EF
{
    public class PDbContext : DbContext
    {
        public DbSet<Product> Card { get; set; }
        public DbSet<Order> Orders { get; set; }

        public PDbContext(DbContextOptions<PDbContext> connectionString)
            : base(connectionString)
        {
            Database.EnsureCreated();
        }
    }
}
