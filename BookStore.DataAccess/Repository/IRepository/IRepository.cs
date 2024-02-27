using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T - Category 
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T,bool>> filter);
        /* we getting expression because we want to make a expression like 
         * Category? categoryFromDb1 = _context.Categories.FirstOrDefault(u => u.Id==id); this is a LINQ expression*/
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
