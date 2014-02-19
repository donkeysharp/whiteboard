using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Whiteboard.DataAccess
{
    public interface IRepository<T>:IDisposable where T: class 
    {
        T Get(long id);
        IEnumerable<T> Filter(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        T Insert(T item);
        int Delete(T item);
        int Update(T item);
        void SaveChanges();
    }
}
