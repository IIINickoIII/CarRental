namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBodyTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[BodyTypes] ON
                  INSERT INTO [dbo].[BodyTypes] ([Id], [Name]) VALUES (1, N'Sedan')
                  INSERT INTO [dbo].[BodyTypes] ([Id], [Name]) VALUES (2, N'Hatchback')
                  INSERT INTO [dbo].[BodyTypes] ([Id], [Name]) VALUES (3, N'Coupe')
                  INSERT INTO [dbo].[BodyTypes] ([Id], [Name]) VALUES (4, N'Station wagon')
                  INSERT INTO [dbo].[BodyTypes] ([Id], [Name]) VALUES (5, N'Cabriolet')
                  INSERT INTO [dbo].[BodyTypes] ([Id], [Name]) VALUES (6, N'Limousine')
                  INSERT INTO [dbo].[BodyTypes] ([Id], [Name]) VALUES (7, N'Pickup')
                  INSERT INTO [dbo].[BodyTypes] ([Id], [Name]) VALUES (8, N'SUV')
                  INSERT INTO [dbo].[BodyTypes] ([Id], [Name]) VALUES (9, N'Minivan')
                  INSERT INTO [dbo].[BodyTypes] ([Id], [Name]) VALUES (10, N'Van')
                  INSERT INTO [dbo].[BodyTypes] ([Id], [Name]) VALUES (11, N'Campervan')
                  SET IDENTITY_INSERT [dbo].[BodyTypes] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
