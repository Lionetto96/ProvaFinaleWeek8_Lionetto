using Rubrica_Core.IRepository;
using Rubrica_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica_RepositoryMock.RepositoryMock
{
    public class RepositoryContatto : IRepositoryContatto
    {
        public static List<Contatto> contatti = new List<Contatto>();
        //{
        //    new Contatto{Nome="alessia",Cognome="lionetto" },
        //    new Contatto{Nome="elisa",Cognome="bianchi" },
        //    new Contatto{Nome="piero",Cognome="rossi" }


        //};
        public Contatto Add(Contatto item)
        {
            if (contatti.Count() == 0)
            {
                item.Id = 1;
            }
            else
            {
                item.Id = contatti.Max(x => x.Id)+1;
            }
            contatti.Add(item);
            return item;
        }

        public bool Delete(Contatto contatto)
        {
            contatti.Remove(contatto);
            return true;
        }

        public ICollection<Contatto> GetAll()
        {
            return contatti;
        }

        public Contatto GetById(int id)
        {
            return contatti.FirstOrDefault(x => x.Id == id);
        }
    }
}
