namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkType");
        }
    }
}
