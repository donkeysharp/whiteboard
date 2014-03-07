using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        internal DataBaseContext context;
        internal DbSet<T> dbSet;

        public GenericRepository()
        {
            this.context = DataBaseContext.Context;
            DataBaseContext.CheckDatabase();
            this.dbSet = context.Set<T>();
        }

        public virtual T Get(long id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> Filter(Expression<Func<T, bool>> filter = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T Insert(T item)
        {
            T newEntry = this.dbSet.Add(item);
            this.context.SaveChanges();
            return newEntry;
        }

        public virtual int Delete(T item)
        {
            if (context.Entry(item).State == System.Data.EntityState.Detached)
            {
                this.dbSet.Attach(item);
            }
            dbSet.Remove(item);
            return context.SaveChanges();
        }

        public virtual int Update(T item)
        {
            if (item == null)
            {
                throw new ApplicationException("Null item not alowed");
            }
            dbSet.Attach(item);
            context.Entry(item).State = System.Data.EntityState.Modified;
            return context.SaveChanges();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
