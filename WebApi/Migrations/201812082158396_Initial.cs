namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                        Preco = c.String(nullable: false, maxLength: 150, unicode: false),
                        CompraGadoItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompraGadoItem", t => t.CompraGadoItem_Id)
                .Index(t => t.CompraGadoItem_Id);
            
            CreateTable(
                "dbo.CompraGadoItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.String(nullable: false, maxLength: 150, unicode: false),
                        CompraGadoId = c.Int(nullable: false),
                        AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompraGado", t => t.CompraGadoId)
                .Index(t => t.CompraGadoId);
            
            CreateTable(
                "dbo.CompraGado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataEntrega = c.DateTime(nullable: false),
                        PecuaristaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pecuarista", t => t.PecuaristaId)
                .Index(t => t.PecuaristaId);
            
            CreateTable(
                "dbo.Pecuarista",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompraGado", "PecuaristaId", "dbo.Pecuarista");
            DropForeignKey("dbo.CompraGadoItem", "CompraGadoId", "dbo.CompraGado");
            DropForeignKey("dbo.Animal", "CompraGadoItem_Id", "dbo.CompraGadoItem");
            DropIndex("dbo.CompraGado", new[] { "PecuaristaId" });
            DropIndex("dbo.CompraGadoItem", new[] { "CompraGadoId" });
            DropIndex("dbo.Animal", new[] { "CompraGadoItem_Id" });
            DropTable("dbo.Pecuarista");
            DropTable("dbo.CompraGado");
            DropTable("dbo.CompraGadoItem");
            DropTable("dbo.Animal");
        }
    }
}
