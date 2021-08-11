using Microsoft.EntityFrameworkCore;
using CardGameSite.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;




namespace CardGameSite.DAL.EF
{
    public class SiteDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoriesProduct { get; set; }

        public SiteDbContext() {}

        public SiteDbContext(DbContextOptions options): base(options) {}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LUCKY-PC\SQLEXPRESS;Database=CardGameSite;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder){}

     }
}
