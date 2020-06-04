namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserNameToAgreementEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agreements", "ClientProfileId", "dbo.ClientProfiles");
            DropIndex("dbo.Agreements", new[] { "ClientProfileId" });
            AddColumn("dbo.Agreements", "UserName", c => c.String());
            DropColumn("dbo.Agreements", "ClientProfileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agreements", "ClientProfileId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Agreements", "UserName");
            CreateIndex("dbo.Agreements", "ClientProfileId");
            AddForeignKey("dbo.Agreements", "ClientProfileId", "dbo.ClientProfiles", "Id", cascadeDelete: true);
        }
    }
}
