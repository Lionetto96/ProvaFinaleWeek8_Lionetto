using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica_Core.Models
{
    public class Contatto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public ICollection<Indirizzo> Indirizzi { get; set; } = new List<Indirizzo>();

        public override string ToString()
        {
            return $"{Id} {Nome} {Cognome} ";
        }
    }
}
