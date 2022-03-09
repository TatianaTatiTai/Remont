namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaterial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Material = c.String(),
                        Manufacturer = c.String(),
                        Сharacteristic = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Material");
        }
    }
}
