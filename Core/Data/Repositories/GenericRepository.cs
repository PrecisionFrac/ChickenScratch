using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ChickenScratch.Data.Repositories
{
    public abstract class GenericRepository<C, E> : IGenericRepository<E>
        where E : class
        where C : DbContext, new()
    {
        private C _entities = new C();

        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public GenericRepository(C context)
        {
            this.Context = context;
        }

        public virtual IQueryable<E> FindAll()
        {
            IQueryable<E> query = _entities.Set<E>();
            return query;
        }

        public async Task<ICollection<E>> FindAllAsync()
        {
            return await _entities.Set<E>().ToListAsync();
        }

        public IQueryable<E> FindBy(System.Linq.Expressions.Expression<Func<E, bool>> predicate)
        {
            IQueryable<E> query = _entities.Set<E>().Where(predicate);
            return query;
        }

        public virtual void Add(E entity)
        {
            _entities.Set<E>().Add(entity);
        }

        public virtual void Remove(E entity)
        {
            _entities.Set<E>().Remove(entity);
        }

        public virtual void Entry(E entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    _entities.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}