using System;
using System.Collections.Generic;
using System.Linq;
using CardGameSite.DAL.Entities;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CardGameSite.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private PDbContext _db;
 
        public ProductRepository(PDbContext context)
        {
            _db = context;
        }

        public ProductRepository(DbContextOptions<PDbContext> connectionOptions)
        {
            _db = new PDbContext(connectionOptions);
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products;
        }

        public Product Get(int id)
        {
            return _db.Products.Find(id);
        }

        public void Create(Product product)
        {
            _db.Products.Add(product);
        }

        public void Update(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
        }

        public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        {
            return _db.Products.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Product product = _db.Products.Find(id);
            if (product != null)
                _db.Products.Remove(product);
        }
    }
}
