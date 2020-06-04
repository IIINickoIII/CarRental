namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedFuelTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[FuelTypes] ON
                  INSERT INTO [dbo].[FuelTypes] ([Id], [Name]) VALUES (1, N'Gasoline')
                  INSERT INTO [dbo].[FuelTypes] ([Id], [Name]) VALUES (2, N'Diesel')
                  INSERT INTO [dbo].[FuelTypes] ([Id], [Name]) VALUES (3, N'Gas')
                  INSERT INTO [dbo].[FuelTypes] ([Id], [Name]) VALUES (4, N'Electric')
                  INSERT INTO [dbo].[FuelTypes] ([Id], [Name]) VALUES (5, N'Hybrid')
                  SET IDENTITY_INSERT [dbo].[FuelTypes] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
