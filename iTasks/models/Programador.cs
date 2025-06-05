using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iTasks.models
{
    public class Programador : Utilizador
    {
        public NivelExperiencia NivelExperiencia { get; set; }
        public Gestor Gestor { get; set; }
        public override string ToString()
        {
            return $"{Nome} ({Username}) - Gestor: {Gestor?.Username}";
        }
    }
    public enum NivelExperiencia
    {
        Júnior,
        Sénior
    }
  
}
