using Microsoft.Extensions.Configuration;
using Scuola.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Controllers
{
    internal class IscrizioneController
    {
            private IConfiguration? configurazione;

            private static IscrizioneController? istanza;

            public static IscrizioneController getIstanza()
            {
                if (istanza == null)
                {
                    istanza = new IscrizioneController();

                    ConfigurationBuilder builder = new ConfigurationBuilder();
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

                    istanza.configurazione = builder.Build();
                }


                return istanza;
            }

            private IscrizioneController()
            {

            }

            public void dettaglioIscrizione(int codIscrizione)
            {
                IscrizioneDAL iscrDal = new IscrizioneDAL(configurazione);

                Console.WriteLine(iscrDal.findById(codIscrizione));
            }
        
    }
}
