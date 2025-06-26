using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.models
{
    public class iTaskcontext : DbContext

    {
        public iTaskcontext() : base("Itaskdb") { }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Programador> Programadores { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TarefaGestor> TarefaGestores { get; set; }
        public DbSet<TipoTarefa> TipoTarefas { get; set; }
     
        public DbSet<Gestor> Gestores { get; set; }


        // Isto impede o SQL Server de apagar automaticamente Tarefas quando apagas um Programador ou Gestor
        // ou seja impede múltiplos cascade delete
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>()
                .HasRequired(t => t.Programador)
                .WithMany()
                .HasForeignKey(t => t.ProgramadorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tarefa>()
                .HasRequired(t => t.Gestor)
                .WithMany()
                .HasForeignKey(t => t.GestorId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

    }
}
