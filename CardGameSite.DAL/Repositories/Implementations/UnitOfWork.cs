using CardGameSite.DAL.Entities;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;


namespace CardGameSite.DAL.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private SiteDbContext _db;
        public IRepository<T> Repository { get; }
        private bool _disposed = false;

        public UnitOfWork(DbContextOptions<SiteDbContext> contextOptions, IRepository<T> _repo)
        {
            _db = new SiteDbContext(contextOptions);
            Repository = _repo;
        }
       
        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
