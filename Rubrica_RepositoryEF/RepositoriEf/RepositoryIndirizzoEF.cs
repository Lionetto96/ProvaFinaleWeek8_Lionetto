using Microsoft.EntityFrameworkCore;
using Rubrica_Core.IRepository;
using Rubrica_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryEF.RepositoriEf
{
    public class RepositoryIndirizzoEF : IRepositoryIndirizzo
    {
        public Indirizzo Add(Indirizzo item)
        {
            using (var ctx = new Context())
            {
                ctx.Indirizzi.Add(item);
                ctx.SaveChanges();

            }
            return item;
        }

        public ICollection<Indirizzo> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Indirizzi.Include(i=>i.Contatto).ToList();
            }
        }

        public Indirizzo GetByIndirizzoId(int id)
        {
            using (var ctx = new Context())
            {
                return ctx.Indirizzi.FirstOrDefault(i => i.IndirizzoId == id);
            }
        }
    }
}
