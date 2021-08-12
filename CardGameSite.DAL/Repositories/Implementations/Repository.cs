using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using CardGameSite.DAL.Entities.Interfaces;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace CardGameSite.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        
        internal protected readonly SiteDbContext _context;
        private readonly DbSet<T> _setT;

        public Repository(SiteDbContext context)
        {
            _context = context;

            _setT = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            Task<IEnumerable<T>> task = Task.Factory.StartNew(() => _setT.AsEnumerable<T>());
            return await task;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _setT.FindAsync(id);
        }

        public async void CreateAsync(T obj)
        {
            await _setT.AddAsync(obj);
        }

        public async void UpdateAsync(T obj)
        {
            T dЬEntity = await _setT.FirstOrDefaultAsync(p => p.Id == obj.Id);
                        
            //System.Diagnostics.Debug.WriteLine("dЬEntity type = " + dЬEntity.GetType().Name);
            
            if (dЬEntity != null)
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                
                foreach (PropertyInfo property in properties)
                {
                    if ( property.Name != "Id" )
                    {
                        typeof(T).GetProperty(property.Name).SetValue(dЬEntity, typeof(T).GetProperty(property.Name).GetValue(obj));
                    }                        
                }
            }            
        }

        public async Task<IEnumerable<T>> FindAsync(Func<T, Boolean> predicate)
        {
            Task<IEnumerable<T>> task = Task.Factory.StartNew(() => _setT.Where(predicate).AsEnumerable<T>());
            return await task;
        }

        public async Task<T> DeleteAsync(int id)
        {
            T obj = await _setT.FindAsync(id);
            if (obj != null)
            {

                Task task = Task.Factory.StartNew(() => _setT.Remove(obj));
                await task;
                return obj;
            }

            return null;
                
        }
    }
}
