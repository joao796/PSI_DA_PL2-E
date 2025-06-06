using iTasks.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Controller
{
    class GereUtilizadoresController
    {


        public bool AdicionarGestor(Gestor gestor)
        {
            using (var context = new iTaskcontext())
            {
                // Verifica se já existe username
                bool exists = context.Utilizadores.Any(u => u.Username == gestor.Username);
                if (exists)
                    return false;

                // Adiciona gestor
                context.Gestores.Add(gestor);
                context.SaveChanges();
                return true;
            }
        }

        public List<Gestor> ListarGestores()
        {
            using (var context = new iTaskcontext())
            {
                return context.Gestores.ToList();
            }
        }


        public bool AdicionarProgramador(Programador programador)
        {
            using (var context = new iTaskcontext())
            {
                // Verifica se já existe username
                bool exists = context.Utilizadores.Any(u => u.Username == programador.Username);
                if (exists)
                    return false;

                // Se o programador tem Gestor definido, carregamos ele do contexto para evitar problema com entidades desconectadas
                if (programador.Gestor != null)
                {
                    var gestorDb = context.Gestores.Find(programador.Gestor.Id);
                    programador.Gestor = gestorDb;
                }

                // Adiciona programador
                context.Programadores.Add(programador);
                context.SaveChanges();
                return true;
            }
        }
        public List<Programador> ListarProgramadores()
        {
            using (var context = new iTaskcontext())
            {

                return context.Programadores.Include("Gestor").ToList();
            }
        }
        public bool ApagarGestor(Gestor gestor)
        {
            using (var context = new iTaskcontext())
            {
                // Verifica se o gestor está em uso (ex: associado a programadores)
                bool emUso = context.Programadores.Any(p => p.Gestor.Id == gestor.Id);
                if (emUso)
                    return false;

                var gestorDb = context.Gestores.FirstOrDefault(g => g.Username == gestor.Username);
                if (gestorDb == null)
                    return false;
          
                context.Gestores.Remove(gestorDb);
                context.SaveChanges();
                return true;
            }
        }
        public bool ApagarProgramador(Programador programador)
        {
            using (var context = new iTaskcontext())
            {
                var programadorDb = context.Programadores.FirstOrDefault(p => p.Username == programador.Username);
                if (programadorDb == null)
                    return false;
                try { 
                context.Programadores.Remove(programadorDb);
                context.SaveChanges();
                return true;
                }
                catch (Exception ex)
                {
                    
                    string message = $"Este programador tem uma tarefa associada {ex.Message}";
                  
                    return false;
                }
            }
        }
    }
}
