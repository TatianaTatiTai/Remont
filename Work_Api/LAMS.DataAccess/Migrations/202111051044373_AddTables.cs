namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderWorkerCost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdOrder = c.String(nullable: false, maxLength: 128),
                        WorkersNumber = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.IdOrder)
                .Index(t => t.IdOrder);
            
            CreateTable(
                "dbo.OrderWorkType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdWorkType = c.Int(nullable: false),
                        IdOrder = c.String(nullable: false, maxLength: 128),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.IdOrder)
                .ForeignKey("dbo.WorkType", t => t.IdWorkType)
                .Index(t => t.IdWorkType)
                .Index(t => t.IdOrder);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderWorkType", "IdWorkType", "dbo.WorkType");
            DropForeignKey("dbo.OrderWorkType", "IdOrder", "dbo.Order");
            DropForeignKey("dbo.OrderWorkerCost", "IdOrder", "dbo.Order");
            DropIndex("dbo.OrderWorkType", new[] { "IdOrder" });
            DropIndex("dbo.OrderWorkType", new[] { "IdWorkType" });
            DropIndex("dbo.OrderWorkerCost", new[] { "IdOrder" });
            DropTable("dbo.OrderWorkType");
            DropTable("dbo.OrderWorkerCost");
        }
    }
}
