namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTransmissionTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[TransmissionTypes] ON
                  INSERT INTO [dbo].[TransmissionTypes] ([Id], [Name]) VALUES (1, N'Front-wheel drive')
                  INSERT INTO [dbo].[TransmissionTypes] ([Id], [Name]) VALUES (2, N'Rear-wheel drive')
                  INSERT INTO [dbo].[TransmissionTypes] ([Id], [Name]) VALUES (3, N'All-wheel drive')
                  SET IDENTITY_INSERT [dbo].[TransmissionTypes] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
