namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarDeliveryEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarDeliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceId = c.Int(nullable: false),
                        DateOfDelivery = c.DateTime(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .Index(t => t.PlaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarDeliveries", "PlaceId", "dbo.Places");
            DropIndex("dbo.CarDeliveries", new[] { "PlaceId" });
            DropTable("dbo.CarDeliveries");
        }
    }
}
