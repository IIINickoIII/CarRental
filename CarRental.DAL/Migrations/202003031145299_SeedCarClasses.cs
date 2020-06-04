namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCarClasses : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[CarClasses] ON
                  INSERT INTO [dbo].[CarClasses] ([Id], [Name]) VALUES (1, N'A CLASS — MINI CARS')
                  INSERT INTO [dbo].[CarClasses] ([Id], [Name]) VALUES (2, N'B CLASS — SMALL CARS')
                  INSERT INTO [dbo].[CarClasses] ([Id], [Name]) VALUES (3, N'С CLASS — MEDIUM CARS')
                  INSERT INTO [dbo].[CarClasses] ([Id], [Name]) VALUES (4, N'D CLASS — LARGE CARS')
                  INSERT INTO [dbo].[CarClasses] ([Id], [Name]) VALUES (5, N'E CLASS — EXECUTIVE CARS')
                  INSERT INTO [dbo].[CarClasses] ([Id], [Name]) VALUES (6, N'F CLASS — LUXURY CARS')
                  INSERT INTO [dbo].[CarClasses] ([Id], [Name]) VALUES (7, N'J CLASS — SPORTS UTILITY')
                  INSERT INTO [dbo].[CarClasses] ([Id], [Name]) VALUES (8, N'M CLASS — MULTI PURPOSE CARS')
                  INSERT INTO [dbo].[CarClasses] ([Id], [Name]) VALUES (9, N'S CLASS — SPORT CARS')
                  SET IDENTITY_INSERT [dbo].[CarClasses] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
