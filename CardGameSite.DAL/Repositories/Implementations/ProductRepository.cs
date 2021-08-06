using System;
using System.Collections.Generic;
using System.Linq;
using CardGameSite.DAL.Entities;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CardGameSite.DAL.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>
    {

        public ProductRepository(DbContextOptions<SiteDbContext> connectionOptions) : base(connectionOptions) 
        {
            _db.Products.Include(c => c.CategoriesProduct).ToList();
        }
                
    }
}
