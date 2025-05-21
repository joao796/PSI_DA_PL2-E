using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.models
{
    public class Programador : Utilizador
    {
        public NivelExperiencia NivelExperiencia { get; set; }
        public Gestor Gestor { get; set; }
    }
    public enum NivelExperiencia
    {
        Júnior,
        Sénior
    }
}
