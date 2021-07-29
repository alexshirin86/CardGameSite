using Microsoft.EntityFrameworkCore;
using CardGameSite.DAL.Entities;


namespace CardGameSite.DAL.EF
{
    public class PDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoriesProduct { get; set; }

        public PDbContext(DbContextOptions<PDbContext> connectionOptions)
            : base(connectionOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>()
                .HasOne(p => p.Product)
                .WithMany(b => b.Categories);
        }
    }
}
