using Microsoft.EntityFrameworkCore;
using CardGameSite.DAL.Entities;


namespace CardGameSite.DAL.EF
{
    public class PDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public PDbContext(DbContextOptions<PDbContext> connectionOptions)
            : base(connectionOptions)
        {
            Database.EnsureCreated();
        }
    }
}
