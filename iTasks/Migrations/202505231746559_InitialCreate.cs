namespace iTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilizadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Departamento = c.Int(),
                        GereUtilizadores = c.Boolean(),
                        NivelExperiencia = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Gestor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadors", t => t.Gestor_Id)
                .Index(t => t.Gestor_Id);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        OrdemExecucao = c.Int(nullable: false),
                        StoryPoints = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataPrevistaInicio = c.DateTime(nullable: false),
                        DataPrevistaFim = c.DateTime(nullable: false),
                        DataRealInicio = c.DateTime(nullable: false),
                        DataRealFim = c.DateTime(nullable: false),
                        EstadoAtual = c.Int(nullable: false),
                        Gestor_Id = c.Int(),
                        Programador_Id = c.Int(),
                        TipoTarefa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadors", t => t.Gestor_Id)
                .ForeignKey("dbo.Utilizadors", t => t.Programador_Id)
                .ForeignKey("dbo.TipoTarefas", t => t.TipoTarefa_Id)
                .Index(t => t.Gestor_Id)
                .Index(t => t.Programador_Id)
                .Index(t => t.TipoTarefa_Id);
            
            CreateTable(
                "dbo.TipoTarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "TipoTarefa_Id", "dbo.TipoTarefas");
            DropForeignKey("dbo.Tarefas", "Programador_Id", "dbo.Utilizadors");
            DropForeignKey("dbo.Tarefas", "Gestor_Id", "dbo.Utilizadors");
            DropForeignKey("dbo.Utilizadors", "Gestor_Id", "dbo.Utilizadors");
            DropIndex("dbo.Tarefas", new[] { "TipoTarefa_Id" });
            DropIndex("dbo.Tarefas", new[] { "Programador_Id" });
            DropIndex("dbo.Tarefas", new[] { "Gestor_Id" });
            DropIndex("dbo.Utilizadors", new[] { "Gestor_Id" });
            DropTable("dbo.TipoTarefas");
            DropTable("dbo.Tarefas");
            DropTable("dbo.Utilizadors");
        }
    }
}
