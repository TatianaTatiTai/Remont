namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOneCostWorkType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkType", "OneCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkType", "OneCost");
        }
    }
}
