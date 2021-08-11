using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using CardGameSite.DAL.Entities.Interfaces;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;



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

        public IEnumerable<T> GetAll()
        {
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
            T dЬEntity = _setT.FirstOrDefault(p => p.Id == obj.Id);
                        
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

        public IEnumerable<T> Find(Func<T, Boolean> predicate)
        {
            return _setT.Where(predicate).ToList();
        }

        public T Delete(int id)
        {
            T obj = _setT.Find(id);
            if (obj != null)
            {
                _setT.Remove(obj);
                return obj;
            }

            return null;
                
        }
    }
}
