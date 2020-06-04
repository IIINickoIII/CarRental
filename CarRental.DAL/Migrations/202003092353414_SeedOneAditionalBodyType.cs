namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedOneAditionalBodyType : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[BodyTypes] ON
                  INSERT INTO [dbo].[BodyTypes] ([Id], [Name]) VALUES (12, N'Utility')
                  SET IDENTITY_INSERT [dbo].[BodyTypes] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
