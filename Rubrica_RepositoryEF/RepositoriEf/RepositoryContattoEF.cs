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
    public class RepositoryContattoEF : IRepositoryContatto
    {
        public RepositoryContattoEF()
        {

        }
        public Contatto Add(Contatto item)
        {
            using (var ctx = new Context())
            {
                ctx.Contatti.Add(item);
                ctx.SaveChanges();

            }
            return item;
        }

        public bool Delete(Contatto contatto)
        {
            using (var ctx = new Context())
            {
                ctx.Contatti.Remove(contatto);
                ctx.SaveChanges();

            }
            return true;
        }

        public ICollection<Contatto> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Contatti.Include(c => c.Indirizzi).ToList();
            }
        }

        public Contatto GetById(int id)
        {
            using (var ctx = new Context())
            {
                return ctx.Contatti.FirstOrDefault(c => c.Id == id);
            }
        }
    }
}
