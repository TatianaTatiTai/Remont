namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditWorkType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderWorkType", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderWorkType", "Amount");
        }
    }
}
