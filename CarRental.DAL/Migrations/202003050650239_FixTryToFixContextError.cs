namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTryToFixContextError : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Deliveries", newName: "CarDeliveries");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CarDeliveries", newName: "Deliveries");
        }
    }
}
