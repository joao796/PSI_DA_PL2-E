using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTasks.models;


namespace iTasks.models
{
    public class TarefaGestor
    {
        public int Id { get; set; }

        // Relações
        public Gestor Gestor { get; set; }
        public int GestorId { get; set; }

        // Dados
        public string Descricao { get; set; }
        public bool Terminado { get; set; }


        public override string ToString()
        {
            return $"#{Descricao}  {Terminado}";
        }
    }
}
