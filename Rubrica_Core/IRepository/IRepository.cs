using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica_Core.IRepository
{
    public interface IRepository<T>
    {
        public ICollection<T> GetAll();
        public T Add(T item);

    }
}
