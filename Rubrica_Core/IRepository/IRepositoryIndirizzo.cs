using Rubrica_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica_Core.IRepository
{
    public interface IRepositoryIndirizzo : IRepository<Indirizzo>
    {
        public Indirizzo GetByIndirizzoId(int id);
    }
}
