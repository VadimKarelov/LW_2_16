using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_16_2.Data.Interfaces
{
    internal interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetList();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
