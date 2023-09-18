using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Models
{
    internal class Corso
    {

        public int Id { get; set; }
        public string? titolo { get; set; }
        public string? codice { get; set; }
        public int? n_ore { get; set; }


        public List<Corso> ElencoCorso { get; set; } = new List<Corso>();
        public override string ToString()
        {
            return $"Persona {Id} {titolo} {codice} {n_ore}";
        }

    }
}
