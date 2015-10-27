using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChickenScratch.Data.Repositories
{
    public interface IGenericRepository<E> where E : class
    {
        IQueryable<E> FindAll();

        Task<ICollection<E>> FindAllAsync();

        IQueryable<E> FindBy(Expression<Func<E, bool>> predicate);

        void Add(E entity);

        void Remove(E entity);

        void Entry(E entity);

        void Save();
    }
}
