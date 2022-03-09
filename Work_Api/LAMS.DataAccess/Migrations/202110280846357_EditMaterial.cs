namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMaterial : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Material");
            AlterColumn("dbo.Material", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Material", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Material");
            AlterColumn("dbo.Material", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Material", "Id");
        }
    }
}
