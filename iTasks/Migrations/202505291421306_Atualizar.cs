namespace iTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atualizar : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tarefas", "TipoTarefa_Id", "dbo.TipoTarefas");
            DropIndex("dbo.Tarefas", new[] { "Gestor_Id" });
            DropIndex("dbo.Tarefas", new[] { "Programador_Id" });
            DropIndex("dbo.Tarefas", new[] { "TipoTarefa_Id" });
            RenameColumn(table: "dbo.Tarefas", name: "Gestor_Id", newName: "GestorId");
            RenameColumn(table: "dbo.Tarefas", name: "Programador_Id", newName: "ProgramadorId");
            RenameColumn(table: "dbo.Tarefas", name: "TipoTarefa_Id", newName: "TipoTarefaId");
            AlterColumn("dbo.Tarefas", "DataRealInicio", c => c.DateTime());
            AlterColumn("dbo.Tarefas", "DataRealFim", c => c.DateTime());
            AlterColumn("dbo.Tarefas", "GestorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tarefas", "ProgramadorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tarefas", "TipoTarefaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tarefas", "GestorId");
            CreateIndex("dbo.Tarefas", "ProgramadorId");
            CreateIndex("dbo.Tarefas", "TipoTarefaId");
            AddForeignKey("dbo.Tarefas", "TipoTarefaId", "dbo.TipoTarefas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "TipoTarefaId", "dbo.TipoTarefas");
            DropIndex("dbo.Tarefas", new[] { "TipoTarefaId" });
            DropIndex("dbo.Tarefas", new[] { "ProgramadorId" });
            DropIndex("dbo.Tarefas", new[] { "GestorId" });
            AlterColumn("dbo.Tarefas", "TipoTarefaId", c => c.Int());
            AlterColumn("dbo.Tarefas", "ProgramadorId", c => c.Int());
            AlterColumn("dbo.Tarefas", "GestorId", c => c.Int());
            AlterColumn("dbo.Tarefas", "DataRealFim", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tarefas", "DataRealInicio", c => c.DateTime(nullable: false));
            RenameColumn(table: "dbo.Tarefas", name: "TipoTarefaId", newName: "TipoTarefa_Id");
            RenameColumn(table: "dbo.Tarefas", name: "ProgramadorId", newName: "Programador_Id");
            RenameColumn(table: "dbo.Tarefas", name: "GestorId", newName: "Gestor_Id");
            CreateIndex("dbo.Tarefas", "TipoTarefa_Id");
            CreateIndex("dbo.Tarefas", "Programador_Id");
            CreateIndex("dbo.Tarefas", "Gestor_Id");
            AddForeignKey("dbo.Tarefas", "TipoTarefa_Id", "dbo.TipoTarefas", "Id");
        }
    }
}
