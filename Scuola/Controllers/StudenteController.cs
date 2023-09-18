using Microsoft.Extensions.Configuration;
using Scuola.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Controllers
{
    internal class StudenteController
    {
        private IConfiguration? configurazione;

        private static StudenteController? istanza;

        public static StudenteController getIstanza()
        {
            if (istanza == null)
            {
                istanza = new StudenteController();

                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

                istanza.configurazione = builder.Build();
            }


            return istanza;
        }

        private StudenteController()
        {

        }

        public void dettaglioStudente(string codStudente)
        {
            StudenteDAL stuDal = new StudenteDAL(configurazione);

            Console.WriteLine(stuDal.findByMatricola(codStudente));
        }
    }
}
