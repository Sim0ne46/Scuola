using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Models
{
    internal class Iscrizione
    {
        public int Id { get; set; }
        public Studente?  studenteRIF { get; set; }
        public Corso? corsoRIF { get; set; }
    }
}
