namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NeedEvaluation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "NeedEvaluation", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "NeedEvaluation");
        }
    }
}
