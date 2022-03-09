namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderMaterial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderMaterial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMaterial = c.Int(nullable: false),
                        IdOrder = c.String(nullable: false, maxLength: 128),
                        Amount = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Material", t => t.IdMaterial)
                .ForeignKey("dbo.Order", t => t.IdOrder)
                .Index(t => t.IdMaterial)
                .Index(t => t.IdOrder);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderMaterial", "IdOrder", "dbo.Order");
            DropForeignKey("dbo.OrderMaterial", "IdMaterial", "dbo.Material");
            DropIndex("dbo.OrderMaterial", new[] { "IdOrder" });
            DropIndex("dbo.OrderMaterial", new[] { "IdMaterial" });
            DropTable("dbo.OrderMaterial");
        }
    }
}
