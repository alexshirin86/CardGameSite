using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CardGameSite.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> FindAsync(Func<T, Boolean> predicate);

        void CreateAsync(T item);
        void UpdateAsync(T item);
        Task<T> DeleteAsync(int id);
    }
}
