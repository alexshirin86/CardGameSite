using System;
using System.Collections.Generic;
using CardGameSite.DAL.Entities;

namespace CardGameSite.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}
