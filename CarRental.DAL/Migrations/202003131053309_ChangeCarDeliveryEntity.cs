namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCarDeliveryEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarDeliveries", "NoDamage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarDeliveries", "NoDamage");
        }
    }
}
