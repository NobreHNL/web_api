namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CompraGado", "Data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompraGado", "Data", c => c.String(maxLength: 150, unicode: false));
        }
    }
}
