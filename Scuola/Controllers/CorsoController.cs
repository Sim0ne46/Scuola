using Microsoft.Extensions.Configuration;
using Scuola.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Controllers
{
    internal class CorsoController
    {
        private IConfiguration? configurazione;

        private static CorsoController? istanza;

        public static CorsoController getIstanza()
        {
            if (istanza == null)
            {
                istanza = new CorsoController();

                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

                istanza.configurazione = builder.Build();
            }


            return istanza;
        }

        private CorsoController()
        {

        }

        public void dettaglioCorso(string codCorso)
        {
            CorsoDAL corDal = new CorsoDAL(configurazione);

            Console.WriteLine(corDal.findByCodice(codCorso));
        }
    }
}
