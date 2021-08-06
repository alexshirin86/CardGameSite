using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using CardGameSite.DAL.Entities;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace CardGameSite.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        
        internal protected readonly SiteDbContext _db;
        private readonly Dictionary<string,string> _setsDbContext;
        private readonly DbSet<T> _setT;

        public Repository(DbContextOptions<SiteDbContext> contextOptions)
        {
            _setsDbContext = new Dictionary<string, string>
            {
                [typeof(Product).Name] = "Products",
                [typeof(CategoryProduct).Name] = "CategoriesProduct",

            };
            _db = new SiteDbContext(contextOptions);
            _setT = (DbSet<T>)typeof(SiteDbContext).GetProperty(_setsDbContext[typeof(T).Name]).GetValue(_db);
        }

        public IEnumerable<T> GetAll()
        {
           //_db.Products.Include(c => c.CategoriesProduct).ToList();

            return _setT;
        }

        public T Get(int id)
        {
            return _setT.Find(id);
        }

        public void Create(T obj)
        {
            _setT.Add(obj);
        }

        public void Update(T obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
        }

        public IEnumerable<T> Find(Func<T, Boolean> predicate)
        {
            return _setT.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Product product = _db.Products.Find(id);
            if (product != null)
                _db.Products.Remove(product);
        }
    }
}
