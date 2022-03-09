namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMaterial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Material", "Description", c => c.String());
            DropColumn("dbo.Material", "Сharacteristic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Material", "Сharacteristic", c => c.String());
            DropColumn("dbo.Material", "Description");
        }
    }
}
