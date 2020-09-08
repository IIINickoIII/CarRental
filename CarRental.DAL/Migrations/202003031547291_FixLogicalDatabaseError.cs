namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixLogicalDatabaseError : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CarDeliveries", newName: "Deliveries");
            DropIndex("dbo.CarReturns", new[] { "PlaceId" });
            CreateTable(
                "dbo.Agreements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientProfileId = c.String(nullable: false, maxLength: 128),
                        CarId = c.Int(nullable: false),
                        DateOfAgreement = c.DateTime(nullable: false),
                        WithChildSeat = c.Boolean(nullable: false),
                        WithGPS = c.Boolean(nullable: false),
                        NumberOfDays = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.ClientProfiles", t => t.ClientProfileId, cascadeDelete: true)
                .Index(t => t.ClientProfileId)
                .Index(t => t.CarId);
            
            AddColumn("dbo.Deliveries", "AgreementId", c => c.Int(nullable: false));
            AddColumn("dbo.Deliveries", "IsDeliveryToUser", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Deliveries", "AgreementId");
            AddForeignKey("dbo.Deliveries", "AgreementId", "dbo.Agreements", "Id", cascadeDelete: true);
            DropTable("dbo.CarReturns");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CarReturns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceId = c.Int(nullable: false),
                        DateOfDelivery = c.DateTime(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Deliveries", "AgreementId", "dbo.Agreements");
            DropForeignKey("dbo.Agreements", "ClientProfileId", "dbo.ClientProfiles");
            DropForeignKey("dbo.Agreements", "CarId", "dbo.Cars");
            DropIndex("dbo.Deliveries", new[] { "AgreementId" });
            DropIndex("dbo.Agreements", new[] { "CarId" });
            DropIndex("dbo.Agreements", new[] { "ClientProfileId" });
            DropColumn("dbo.Deliveries", "IsDeliveryToUser");
            DropColumn("dbo.Deliveries", "AgreementId");
            DropTable("dbo.Agreements");
            CreateIndex("dbo.CarReturns", "PlaceId");
            RenameTable(name: "dbo.Deliveries", newName: "CarDeliveries");
        }
    }
}
