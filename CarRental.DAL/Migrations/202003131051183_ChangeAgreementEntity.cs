namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAgreementEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agreements", "IsConfirmd", c => c.Boolean(nullable: false));
            AddColumn("dbo.Agreements", "IsPayed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agreements", "IsPayed");
            DropColumn("dbo.Agreements", "IsConfirmd");
        }
    }
}
