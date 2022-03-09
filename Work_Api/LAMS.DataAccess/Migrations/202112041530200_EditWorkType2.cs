namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditWorkType2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderWorkType", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderWorkType", "Amount", c => c.Int(nullable: false));
        }
    }
}
