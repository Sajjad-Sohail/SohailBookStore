using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        bool Add(T item);
        bool Delete(T item);
        bool Edit(T item);

    }
}
