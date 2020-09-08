namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictureLinkToManufacturerEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manufacturers", "PictureLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Manufacturers", "PictureLink");
        }
    }
}
