namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAgreementEntity1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agreements", "Name", c => c.String());
            AddColumn("dbo.Agreements", "Surname", c => c.String());
            AddColumn("dbo.Agreements", "Personald", c => c.String());
            AddColumn("dbo.Agreements", "WithDriver", c => c.Boolean(nullable: false));
            AddColumn("dbo.Agreements", "ManagerComment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agreements", "ManagerComment");
            DropColumn("dbo.Agreements", "WithDriver");
            DropColumn("dbo.Agreements", "Personald");
            DropColumn("dbo.Agreements", "Surname");
            DropColumn("dbo.Agreements", "Name");
        }
    }
}
