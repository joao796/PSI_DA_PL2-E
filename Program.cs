using iTasks.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*using (var db = new iTaskcontext())
            {
                var gestor = new Gestor { Nome = "admin", Username = "admin", Password = "admin", Departamento = "Administração", GereUtilizadores = true };
                db.Gestores.Add(gestor);
                db.SaveChanges();
            }
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
  
           
        }
    }
}
