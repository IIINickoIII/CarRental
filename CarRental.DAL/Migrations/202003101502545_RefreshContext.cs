namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshContext : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "PictureLink");
            DropColumn("dbo.Manufacturers", "PictureLink");
            DropColumn("dbo.Places", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Places", "Description", c => c.String());
            AddColumn("dbo.Manufacturers", "PictureLink", c => c.String());
            AddColumn("dbo.Cars", "PictureLink", c => c.String());
        }
    }
}
