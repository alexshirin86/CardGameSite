﻿using CardGameSite.DAL.EF;
using CardGameSite.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;


namespace CardGameSite.DAL.Repositories
{
    public class EFUnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private PDbContext _db;
        public IRepository<T> Repository { get; }
        private bool _disposed = false;

        public EFUnitOfWork(DbContextOptions<PDbContext> connectionString, IRepository<T> _repo)
        {
            _db = new PDbContext(connectionString);
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
