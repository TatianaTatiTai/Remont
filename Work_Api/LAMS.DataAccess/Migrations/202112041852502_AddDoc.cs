namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdOrder = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        SavedDate = c.DateTime(),
                        Extension = c.String(),
                        Number = c.Int(nullable: false),
                        Text = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.IdOrder)
                .Index(t => t.IdOrder);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "IdOrder", "dbo.Order");
            DropIndex("dbo.Documents", new[] { "IdOrder" });
            DropTable("dbo.Documents");
        }
    }
}
