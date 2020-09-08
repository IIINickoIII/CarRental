namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictureLinkToCarEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "PictureLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "PictureLink");
        }
    }
}
