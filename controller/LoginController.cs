using iTasks.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks.Controller
{
    class LoginController
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Itaskdb;";

        public bool Login(Utilizador login)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Utilizadors WHERE Username = @Username AND password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", login.Username);
                cmd.Parameters.AddWithValue("@Password", login.Password);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}