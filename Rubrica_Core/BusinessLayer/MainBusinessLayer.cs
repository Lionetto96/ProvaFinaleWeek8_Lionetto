using Rubrica_Core.IRepository;
using Rubrica_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica_Core.BusinessLayer
{
    public class MainBusinessLayer :IBusinessLayer
    {
        private readonly IRepositoryContatto contattiRepo;
        private readonly IRepositoryIndirizzo indirizziRepo;

        public MainBusinessLayer(IRepositoryContatto contatti, IRepositoryIndirizzo indirizzi)
        {
            contattiRepo = contatti;
            indirizziRepo = indirizzi;
        }

        public Esito AddNuovoContatto(Contatto nuovoContatto)
        {
            //controllo se id inserito esiste 
            Contatto contattoEsistente = contattiRepo.GetById(nuovoContatto.Id);

            if (contattoEsistente == null)
            {
                //aggiungo il nuovo studente
                contattiRepo.Add(nuovoContatto);
                return new Esito { Messaggio = "contatto aggiunto", IsOk = true };
            }
            else
            {
                return new Esito { Messaggio = "impossibile aggiungere il contatto", IsOk = false };
            }
        }

        public Esito AddNuovoIndirizzo(Indirizzo indirizzoNuovo)
        {
            Indirizzo indirizzoEsistente = indirizziRepo.GetByIndirizzoId(indirizzoNuovo.IndirizzoId);
            if (indirizzoEsistente == null)
            {
                indirizziRepo.Add(indirizzoNuovo);
                return new Esito { Messaggio="indirizzo aggiunto", IsOk=true };
            }
            else
            {
                return new Esito { Messaggio = "impossibile aggiungere indirizzo", IsOk = false };
            }
        }

        public Esito DeleteContatto(int id)
        {
            var contattoEsistente = contattiRepo.GetById(id);
            if (contattoEsistente == null)
            {
                return new Esito { Messaggio = "id non trovato", IsOk = false };


            }
            else
            {
                List<Indirizzo> listaIndirizziContatto = indirizziRepo.GetAll().ToList();
                List <Indirizzo> list=listaIndirizziContatto.Where(x=>x.ContattoId == id).ToList();
                if (list.Count() == 0 )
                {
                    contattiRepo.Delete(contattoEsistente);
                    return new Esito { Messaggio = "contatto eliminato correttamente", IsOk = true };


                }
                else
                {
                    return new Esito { Messaggio = "contatto non eliminato correttamente perchè non c'è nessun indirizzo associato ad esso", IsOk = false };
                }

            }
        }

        public List<Contatto> GetAllContatti()
        {
            return contattiRepo.GetAll().ToList();
        }

        public List<Indirizzo> GetAllIndirizzi()
        {
            return indirizziRepo.GetAll().ToList();
        }
    }

}
