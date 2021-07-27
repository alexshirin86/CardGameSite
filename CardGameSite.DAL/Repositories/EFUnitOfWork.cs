using System;
using System.Collections.Generic;
using System.Linq;
using CardGameSite.DAL.Entities;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CardGameSite.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private PDbContext db;
        private ProductRepository productRepository;
        private OrderRepository orderRepository;

        public EFUnitOfWork(DbContextOptions<PDbContext> connectionOptions)
        {
            db = new PDbContext(connectionOptions);
        }
        public IRepository<Product> Products {
            get {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public IRepository<Order> Orders {
            get {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
