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
    internal class CorsoDAL : IDal<Corso>
    {
        private string? stringaConnessione;
        private IConfiguration? conf;

        public CorsoDAL(IConfiguration? configurazione)
        {
            conf = configurazione;
            if (configurazione != null)
                stringaConnessione = configurazione.GetConnectionString("DatabaseLocale");
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Corso> findAll()
        {
            throw new NotImplementedException();
        }

        public Corso? findById(int id)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT corsoID, titolo, codice, n_ore FROM Corso WHERE corsoID = @varId;";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varId", id);
                comando.Connection = connessione;

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                try
                {
                    reader.Read();

                    Corso corso = new Corso()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        titolo = reader[1].ToString(),
                        codice = reader[2].ToString(),
                        n_ore = Convert.ToInt32(reader[3]),
                    };

                    connessione.Close();
                    return corso;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connessione.Close();
                    return null;
                }
            }
        }

        public bool insert(Corso z)
        {
            throw new NotImplementedException();
        }

        public bool update(Corso z)
        {
            throw new NotImplementedException();
        }

        public Corso? findByCodice(string varCodice)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "corsoID, titolo, codice, n_ore FROM Corso WHERE codice = @varCod;";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varCod", varCodice);
                comando.Connection = connessione;

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                try
                {
                    reader.Read();

                    Corso corso= new Corso()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        titolo = reader[1].ToString(),
                        codice = reader[2].ToString(),
                        n_ore = Convert.ToInt32(reader[3]),
                    };

                    connessione.Close();
                    return corso;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connessione.Close();
                    return null;
                }
            }
        }
    }
}
