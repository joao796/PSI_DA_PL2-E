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
    }
}
