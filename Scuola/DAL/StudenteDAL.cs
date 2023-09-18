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
    internal class StudenteDAL : IDal<Studente>
    {

        private string? stringaConnessione;
        private IConfiguration? conf;

        public StudenteDAL(IConfiguration? configurazione)
        {
            conf = configurazione;
            if (configurazione != null)
                stringaConnessione = configurazione.GetConnectionString("DatabaseLocale");
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Studente> findAll()
        {
            throw new NotImplementedException();
        }


        public Studente? findById(int id)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT studenteID, nome, cognome, matricola FROM Studente WHERE studenteID = @varId;";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varId", id);
                comando.Connection = connessione;

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                try
                {
                    reader.Read();

                    Studente studente = new Studente()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        nome = reader[1].ToString(),
                        cognome = reader[2].ToString(),
                        matricola = reader[2].ToString(),
                    };

                    connessione.Close();
                    return studente;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connessione.Close();
                    return null;
                }
            }
        }

        public bool insert(Studente z)
        {
            throw new NotImplementedException();
        }

        public bool update(Studente z)
        {
            throw new NotImplementedException();
        }

        public Studente? findByMatricola(string varMatricola)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT studenteID, nome, cognome, matricola FROM Studente  WHERE matricola = @varCod;";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varCod", varMatricola);
                comando.Connection = connessione;

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                try
                {
                    reader.Read();

                    Studente carta = new Studente()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        nome = reader[1].ToString(),
                        cognome = reader[2].ToString(),
                        matricola = reader[2].ToString(),
                    };

                    connessione.Close();
                    return carta;
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
