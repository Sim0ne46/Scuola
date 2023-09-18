using Scuola.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Scuola.DAL
{
    internal class IscrizioneDAL : IDal<Iscrizione>
    {
        private string? stringaConnessione;
        private IConfiguration? conf;

        public IscrizioneDAL(IConfiguration? configurazione)
        {
            conf = configurazione;
            if (configurazione != null)
                stringaConnessione = configurazione.GetConnectionString("DatabaseLocale");
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Iscrizione> findAll()
        {
            throw new NotImplementedException();
        }

        public Iscrizione? findById(int id)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT Studente.nome, Studente.cognome,Studente.matricola, Corso.titolo, Corso.codice, Corso.n_ore FROM Studente JOIN Iscrizione ON Studente.studenteID = Iscrizione.studenteRIF  JOIN Corso ON Iscrizione.corsoRIF = Corso.corsoID WHERE studenteID = @varId ;";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varId", id);
                comando.Connection = connessione;

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                try
                {
                    reader.Read();

                    Iscrizione iscrizione = new Iscrizione()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        // studenteRIF = reader[1] is DBNull ? (Studente?)null : new Studente(reader[1].ToString()),
                       // corsoRIF = reader[1] is DBNull ? (Corso?)null : new Corso(reader[1].ToString()),
                    };

                    connessione.Close();
                    return iscrizione;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connessione.Close();
                    return null;
                }
            }
        }

        public bool insert(Iscrizione z)
        {
            throw new NotImplementedException();
        }

        public bool update(Iscrizione z)
        {
            throw new NotImplementedException();
        }
    }
}
