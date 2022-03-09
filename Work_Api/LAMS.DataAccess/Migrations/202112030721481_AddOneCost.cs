namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOneCost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Material", "OneCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Material", "OneCost");
        }
    }
}
