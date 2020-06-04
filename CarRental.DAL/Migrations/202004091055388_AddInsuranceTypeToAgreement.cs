namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsuranceTypeToAgreement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agreements", "InsuranceType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agreements", "InsuranceType");
        }
    }
}
