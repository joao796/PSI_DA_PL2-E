using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.models
{
    public class Gestor : Utilizador
    {
        public Departamento Departamento { get; set; }
        public bool GereUtilizadores { get; set; }
    }
    public enum Departamento
    {
        IT,
        Marketing,
        Administração
    }
}
