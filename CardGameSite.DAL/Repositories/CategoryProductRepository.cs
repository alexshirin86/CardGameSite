using System;
using System.Linq;
using System.Collections.Generic;
using CardGameSite.DAL.Entities;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CardGameSite.DAL.Repositories
{
    class CategoryProductRepository : IRepository<CategoryProduct>
    {
        private PDbContext _db;

        public CategoryProductRepository(PDbContext context)
        {
            _db = context;
        }

        public CategoryProductRepository(DbContextOptions<PDbContext> connectionOptions)
        {
            _db = new PDbContext(connectionOptions);
        }

        public IEnumerable<CategoryProduct> GetAll()
        {
            return _db.CategoriesProduct;
        }

        public CategoryProduct Get(int id)
        {
            return _db.CategoriesProduct.Find(id);
        }

        public void Create(CategoryProduct category)
        {
            _db.CategoriesProduct.Add(category);
        }

        public void Update(CategoryProduct category)
        {
            _db.Entry(category).State = EntityState.Modified;
        }

        public IEnumerable<CategoryProduct> Find(Func<CategoryProduct, Boolean> predicate)
        {
            return _db.CategoriesProduct.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            CategoryProduct category = _db.CategoriesProduct.Find(id);
            if (category != null)
                _db.CategoriesProduct.Remove(category);
        }
    }
}
