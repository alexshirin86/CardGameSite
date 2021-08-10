﻿using Microsoft.EntityFrameworkCore;
using CardGameSite.DAL.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace CardGameSite.DAL.EF
{
    public class SiteDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoriesProduct { get; set; }

        public SiteDbContext(DbContextOptions<SiteDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LUCKY-PC\SQLEXPRESS;Database=CardGameSite;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }
        
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany<CategoryProduct>(s => s.Categories)
                .WithMany(c => c.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCategoryProduct",
                    j => j
                        .HasOne<CategoryProduct>()
                        .WithMany()
                        .HasForeignKey("id")
                        .HasConstraintName("categoryProductId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Product>()
                        .WithMany()
                        .HasForeignKey("id")
                        .HasConstraintName("productId")
                        .OnDelete(DeleteBehavior.ClientCascade));
                            
        }*/
        
    }
}