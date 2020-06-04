namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGearboxTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[GearboxTypes] ON
                  INSERT INTO [dbo].[GearboxTypes] ([Id], [Name]) VALUES (1, N'Auto')
                  INSERT INTO [dbo].[GearboxTypes] ([Id], [Name]) VALUES (2, N'Manual')
                  SET IDENTITY_INSERT [dbo].[GearboxTypes] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
