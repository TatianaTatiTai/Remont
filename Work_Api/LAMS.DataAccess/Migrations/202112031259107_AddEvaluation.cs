namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEvaluation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdOrder = c.String(nullable: false, maxLength: 128),
                        Evaluation = c.String(),
                        DateEvaluation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.IdOrder)
                .Index(t => t.IdOrder);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluation", "IdOrder", "dbo.Order");
            DropIndex("dbo.Evaluation", new[] { "IdOrder" });
            DropTable("dbo.Evaluation");
        }
    }
}
