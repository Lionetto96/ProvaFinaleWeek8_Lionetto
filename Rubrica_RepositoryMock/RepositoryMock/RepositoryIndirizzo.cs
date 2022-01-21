using Rubrica_Core.IRepository;
using Rubrica_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica_RepositoryMock.RepositoryMock
{
    public class RepositoryIndirizzo : IRepositoryIndirizzo
    {
        public static List<Indirizzo> indirizzi = new List<Indirizzo>();
        //{
        //    new Indirizzo{Tipologia="Domicilio", Via="via lessona 12", Città="Milano",
        //    Cap="20189",Provincia="Milano", Nazione="Italia",ContattoId=1 },
        //    new Indirizzo{Tipologia="Residenza", Via="via roma 1", Città="Roma",
        //    Cap="21230",Provincia="Roma", Nazione="Italia",ContattoId=2 },
        //    new Indirizzo{Tipologia="Residenza", Via="via milano 1", Città="Bologna",
        //    Cap="20245",Provincia="Bologna", Nazione="Italia" }
        //};

        public Indirizzo Add(Indirizzo item)
        {
            if (indirizzi.Count() == 0)
            {
                item.IndirizzoId=1;
            }
            else
            {
                item.IndirizzoId = indirizzi.Max(x => x.IndirizzoId) + 1;
            }
            indirizzi.Add(item);
            return item;
        }

        public ICollection<Indirizzo> GetAll()
        {
            return indirizzi;
        }

        public Indirizzo GetByIndirizzoId(int id)
        {
            return indirizzi.FirstOrDefault(x=>x.IndirizzoId == id);
        }
    }
}
