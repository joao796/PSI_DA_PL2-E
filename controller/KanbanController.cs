using iTasks.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iTasks.Controller
{
    class KanbanController
    {
        
        public string CurrentUsername { get; set; }

        public string GetNomeDoUtilizador(string username)
        {
            using (var context = new iTaskcontext())
            {
                var utilizador = context.Utilizadores
                    .Where(u => u.Username == username)
                    .Select(u => u.Nome)
                    .FirstOrDefault();

                return utilizador; // retorna string ou null se não encontrado
            }
        }
        public bool PodeGerirUtilizadores(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            using (var context = new iTaskcontext())
            {
                return context.Gestores.Any(g => g.Username == username && g.GereUtilizadores);
            }
        }
    }
}
