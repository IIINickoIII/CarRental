namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeManufacturerFieldOfCarNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Cars", new[] { "ManufacturerId" });
            AlterColumn("dbo.Cars", "ManufacturerId", c => c.Int());
            CreateIndex("dbo.Cars", "ManufacturerId");
            AddForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Cars", new[] { "ManufacturerId" });
            AlterColumn("dbo.Cars", "ManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "ManufacturerId");
            AddForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
        }
    }
}
