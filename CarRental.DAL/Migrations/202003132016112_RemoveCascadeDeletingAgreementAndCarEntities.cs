namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCascadeDeletingAgreementAndCarEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agreements", "CarId", "dbo.Cars");
            DropIndex("dbo.Agreements", new[] { "CarId" });
            AlterColumn("dbo.Agreements", "CarId", c => c.Int());
            CreateIndex("dbo.Agreements", "CarId");
            AddForeignKey("dbo.Agreements", "CarId", "dbo.Cars", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agreements", "CarId", "dbo.Cars");
            DropIndex("dbo.Agreements", new[] { "CarId" });
            AlterColumn("dbo.Agreements", "CarId", c => c.Int(nullable: false));
            CreateIndex("dbo.Agreements", "CarId");
            AddForeignKey("dbo.Agreements", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
        }
    }
}
