using System;
using System.Threading.Tasks;


namespace CardGameSite.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T: class
    {
        IRepository<T> Repository { get; }
        Task<int> SaveAsync();
    }
}
