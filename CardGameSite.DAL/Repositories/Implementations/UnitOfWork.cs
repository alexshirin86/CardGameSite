using CardGameSite.DAL.Entities.Interfaces;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Repositories.Interfaces;
using System.Threading.Tasks;

using System;


namespace CardGameSite.DAL.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class, IEntity
    {
        private SiteDbContext _context;
        public IRepository<T> Repository { get; }
        private bool _disposed = false;

        public UnitOfWork(SiteDbContext context, IRepository<T> _repo)
        {
            _context = context;
            Repository = _repo;
        }
       
        public void Save()
        {
            //System.Diagnostics.Debug.WriteLine("Save is " + _context.SaveChanges());
            _context.SaveChangesAsync();
        }

        
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
