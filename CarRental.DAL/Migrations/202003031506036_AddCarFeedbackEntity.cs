namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarFeedbackEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        ClientProfileId = c.String(nullable: false, maxLength: 128),
                        DateOfFeedback = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.ClientProfiles", t => t.ClientProfileId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.ClientProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarFeedbacks", "ClientProfileId", "dbo.ClientProfiles");
            DropForeignKey("dbo.CarFeedbacks", "CarId", "dbo.Cars");
            DropIndex("dbo.CarFeedbacks", new[] { "ClientProfileId" });
            DropIndex("dbo.CarFeedbacks", new[] { "CarId" });
            DropTable("dbo.CarFeedbacks");
        }
    }
}
