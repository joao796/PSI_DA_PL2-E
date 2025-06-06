using iTasks.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Controller
{
    class TarefasConcluidasController
    {
        public bool TipoUtilizador(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            using (var context = new iTaskcontext())
            {
                return context.Gestores.Any(g => g.Username == username);
            }
        }


    }
}
