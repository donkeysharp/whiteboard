using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whiteboard.BusinessLogic
{
    public interface IService<T>
    {
        T Get(int id);
        T Insert(T item);
        int Update(T item);
        int Delete(T item);
        IEnumerable<T> GetAll();
    }
}
