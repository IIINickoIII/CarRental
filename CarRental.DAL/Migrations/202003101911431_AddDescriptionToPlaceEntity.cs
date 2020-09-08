namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToPlaceEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "Description");
        }
    }
}
