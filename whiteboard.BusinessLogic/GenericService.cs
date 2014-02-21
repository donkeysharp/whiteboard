using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess;

namespace whiteboard.BusinessLogic
{
    public class GenericService<T> : IService<T> where T : class
    {
        protected IRepository<T> da;

        protected GenericService(IRepository<T> da)
        {
            this.da = da;
        }

        public virtual T Get(int id)
        {
            return da.Get(id);   
        }
        public virtual T Insert(T item)
        {
            return da.Insert(item);
        }

        public virtual int Update(T item)
        {
            return da.Update(item);
        }

        public IEnumerable<T> GetAll()
        {
            return da.Filter(null, null);
        }
    }
}
