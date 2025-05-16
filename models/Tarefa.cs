﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public Gestor Gestor { get; set; }
        public Programador Programador { get; set; }
        public int OrdemExecucao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPrevistaInicio { get; set; }
        public DateTime DataPrevistaFim { get; set; }
        public TipoTarefa TipoTarefa { get; set; }
        public int StoryPoints { get; set; }
        public DateTime DataRealInicio { get; set; }
        public DateTime DataRealFim { get; set; }
        public DateTime DataCriacao { get; set; }
        public string EstadoAtual { get; set; }
    }
}
