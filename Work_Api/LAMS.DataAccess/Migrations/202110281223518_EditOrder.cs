namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Fio", c => c.String());
            AddColumn("dbo.Order", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Phone");
            DropColumn("dbo.Order", "Fio");
        }
    }
}
