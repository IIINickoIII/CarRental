namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedManufacturers : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[Manufacturers] ON
                  INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [Description], [Country], [IsDeleted]) VALUES (1, N'Toyota', N'No)', N'Japan', 0)
                  INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [Description], [Country], [IsDeleted]) VALUES (2, N'Volkswagen', N'NoNoNo', N'Germany', 0)
                  INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [Description], [Country], [IsDeleted]) VALUES (3, N'Hyundai', N'Not yet', N'South Korea', 0)
                  SET IDENTITY_INSERT [dbo].[Manufacturers] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
