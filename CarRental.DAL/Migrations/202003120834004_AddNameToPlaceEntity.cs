namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToPlaceEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "Name");
        }
    }
}
