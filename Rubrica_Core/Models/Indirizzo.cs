using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica_Core.Models
{
    public class Indirizzo
    {
        public int IndirizzoId { get; set; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Città { get; set; }
        public string Cap { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }

        public int ContattoId { get; set; }
        public Contatto Contatto { get; set; }

        public override string ToString()
        {
            return $"{IndirizzoId} {Tipologia} {Via} {Città} {Cap} {Provincia} {Nazione}";
        }
    }
}
