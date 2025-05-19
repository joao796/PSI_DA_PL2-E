using iTasks.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Controller
{
    class GereUtilizadoresController
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Itaskdb;";

        public bool AdicionarGestor(Gestor gestor)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Utilizadors (Nome, Username, Password, Departamento, Discriminator, GereUtilizadores) " +
                               "VALUES (@Nome, @Username, @Password, @Departamento, @Discriminator, @GereUtilizadores)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", gestor.Nome);
                cmd.Parameters.AddWithValue("@Username", gestor.Username);
                cmd.Parameters.AddWithValue("@Password", gestor.Password);
                cmd.Parameters.AddWithValue("@Departamento", gestor.Departamento);
                cmd.Parameters.AddWithValue("@Discriminator", "Gestor");
                cmd.Parameters.AddWithValue("@GereUtilizadores", gestor.GereUtilizadores);
                int linhasAfetadas = cmd.ExecuteNonQuery();
                return linhasAfetadas > 0;
            }
        }

        public List<Gestor> ListarGestores()
        {
            var lista = new List<Gestor>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Nome, Username, Departamento FROM Utilizadors";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Gestor
                        {
                            Nome = reader["Nome"].ToString(),
                            Username = reader["Username"].ToString(),
                            Departamento = reader["Departamento"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
        public bool AdicionarProgramador(Programador programador)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Utilizadors (Nome, Username, Password, , Discriminator, NivelExperiencia, Gestor ) " +
                               "VALUES (@Nome, @Username, @Password, @Discriminator, @NivelExperiencia, @Gestor)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", programador.Nome);
                cmd.Parameters.AddWithValue("@Username", programador.Username);
                cmd.Parameters.AddWithValue("@Password", programador.Password);
                cmd.Parameters.AddWithValue("@NivelExperiencia", programador.NivelExperiencia);
                cmd.Parameters.AddWithValue("@Discriminator", "Programador");
                cmd.Parameters.AddWithValue("@gestor", programador.Gestor);
                int linhasAfetadas = cmd.ExecuteNonQuery();
                return linhasAfetadas > 0;
            }
        }
        public List<Programador> ListarProgramadores()
        {
            var lista = new List<Programador>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Nome, Username, NivelExperiencia FROM Utilizadors";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Programador
                        {
                            Nome = reader["Nome"].ToString(),
                            Username = reader["Username"].ToString(),
                            NivelExperiencia = reader["NivelExperiencia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }
    }
}
