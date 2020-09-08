namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarAndCarsRelatedEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        LicensePlate = c.String(nullable: false),
                        ProductionYear = c.String(nullable: false),
                        PricePerDay = c.Int(nullable: false),
                        NumberOfSeats = c.Int(nullable: false),
                        WithAirConditioning = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        FuelTypeId = c.Int(nullable: false),
                        GearboxTypeId = c.Int(nullable: false),
                        TransmissionTypeId = c.Int(nullable: false),
                        CarClassId = c.Int(nullable: false),
                        BodyTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyTypes", t => t.BodyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.CarClasses", t => t.CarClassId, cascadeDelete: true)
                .ForeignKey("dbo.FuelTypes", t => t.FuelTypeId, cascadeDelete: true)
                .ForeignKey("dbo.GearboxTypes", t => t.GearboxTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.TransmissionTypes", t => t.TransmissionTypeId, cascadeDelete: true)
                .Index(t => t.ManufacturerId)
                .Index(t => t.FuelTypeId)
                .Index(t => t.GearboxTypeId)
                .Index(t => t.TransmissionTypeId)
                .Index(t => t.CarClassId)
                .Index(t => t.BodyTypeId);
            
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GearboxTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        Country = c.String(nullable: false, maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransmissionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Cars", "GearboxTypeId", "dbo.GearboxTypes");
            DropForeignKey("dbo.Cars", "FuelTypeId", "dbo.FuelTypes");
            DropForeignKey("dbo.Cars", "CarClassId", "dbo.CarClasses");
            DropForeignKey("dbo.Cars", "BodyTypeId", "dbo.BodyTypes");
            DropIndex("dbo.Cars", new[] { "BodyTypeId" });
            DropIndex("dbo.Cars", new[] { "CarClassId" });
            DropIndex("dbo.Cars", new[] { "TransmissionTypeId" });
            DropIndex("dbo.Cars", new[] { "GearboxTypeId" });
            DropIndex("dbo.Cars", new[] { "FuelTypeId" });
            DropIndex("dbo.Cars", new[] { "ManufacturerId" });
            DropTable("dbo.TransmissionTypes");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.GearboxTypes");
            DropTable("dbo.FuelTypes");
            DropTable("dbo.Cars");
            DropTable("dbo.CarClasses");
            DropTable("dbo.BodyTypes");
        }
    }
}
