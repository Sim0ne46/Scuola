using Scuola.Controllers;

namespace Scuola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CorsoController.getIstanza().dettaglioCorso("GGRTT7675");
            StudenteController.getIstanza().dettaglioStudente("CDT389JF");
            IscrizioneController.getIstanza().dettaglioIscrizione(1);
        }
    }
}