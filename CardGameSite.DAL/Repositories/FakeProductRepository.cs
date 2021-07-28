using System;
using System.Collections.Generic;
using System.Linq;
using CardGameSite.DAL.Entities;
using CardGameSite.DAL.Interfaces;


namespace CardGameSite.DAL.Repositories
{
    public class FakeProductRepository : IRepository<Product>
    {
        private List<Product> _products;

        public FakeProductRepository()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Товар 1", Description = "Описание 1", Price = 3.99M, Category = 1},
                new Product { Id = 2, Name = "Товар 2", Description = "Описание 2", Price = 5.99M, Category = 1},
                new Product { Id = 3, Name = "Товар 3", Description = "Описание 3", Price = 7.99M, Category = 2},
                new Product { Id = 4, Name = "Товар 4", Description = "Описание 4", Price = 2.99M, Category = 2},
                new Product { Id = 5, Name = "Товар 5", Description = "Описание 5", Price = 0.99M, Category = 2},
                new Product { Id = 6, Name = "Товар 6", Description = "Описание 6", Price = 1.99M, Category = 3},
                new Product { Id = 7, Name = "Товар 7", Description = "Описание 7", Price = 3.99M, Category = 3},
            };
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product Get(int id)
        {
            return (Product)_products.Where(p => p.Id == id);
        }

        public void Create(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            _products[ _products.ToList().FindIndex(p => p.Id == product.Id) ] = product;
        }

        public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        {
            return _products.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            _products.Remove( _products.Find(p => p.Id == id) );
        }
    }
}
