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
    public class LoginController
    {
        public bool Login(Utilizador login)
        {
            using (var context = new iTaskcontext())
            {
                var exists = (from u in context.Utilizadores
                              where u.Username == login.Username && u.Password == login.Password
                              select u).Any();

                return exists;
            }
        }
    }
}