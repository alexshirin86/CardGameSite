﻿using System;


namespace CardGameSite.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T: class
    {
        IRepository<T> Repository { get; }
        void Save();
    }
}