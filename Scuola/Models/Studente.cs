using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Models
{
    internal class Studente
    {

        public int Id { get; set; }
        public string? nome { get; set; }
        public string? cognome { get; set; }
        public string? matricola { get; set; }


        public List<Studente> studente { get; set; } = new List<Studente>();
        public override string ToString()
        {
            return $"Persona {Id} {nome} {cognome} {matricola}";
        }

    }
}
