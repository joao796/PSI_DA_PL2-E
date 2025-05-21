using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Controller
{
    class KanbanController
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Itaskdb;";
        public string CurrentUsername { get; set; }

        public string GetNomeDoUtilizador(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT Nome FROM Utilizadors WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                object result = cmd.ExecuteScalar();

                return result != null ? result.ToString() : null;
            }
        }
        public bool PodeGerirUtilizadores()
        {
            string currentUsername = frmLogin.SessaoUsuario.Username;

            if (string.IsNullOrEmpty(currentUsername))
                return false; // Ninguém logado

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT GereUtilizadores FROM Utilizadors WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", currentUsername);

                object result = cmd.ExecuteScalar();

                return result != null && Convert.ToBoolean(result);
            }
        }
    }
}
