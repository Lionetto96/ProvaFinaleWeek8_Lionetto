using Rubrica_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica_Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        List<Contatto> GetAllContatti();
        List<Indirizzo> GetAllIndirizzi();
        Esito DeleteContatto(int id);
        Esito AddNuovoContatto(Contatto nuovoContatto);
        Esito AddNuovoIndirizzo(Indirizzo indirizzoNuovo);
    }
}
