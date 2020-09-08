namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarIdToCarDelivery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarDeliveries", "CarId", c => c.Int());
            CreateIndex("dbo.CarDeliveries", "CarId");
            AddForeignKey("dbo.CarDeliveries", "CarId", "dbo.Cars", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarDeliveries", "CarId", "dbo.Cars");
            DropIndex("dbo.CarDeliveries", new[] { "CarId" });
            DropColumn("dbo.CarDeliveries", "CarId");
        }
    }
}
