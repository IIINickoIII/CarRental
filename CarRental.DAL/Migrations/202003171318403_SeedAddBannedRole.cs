namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAddBannedRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'6a666f6f-6666-6666-b66f-6cd666bf6cca', N'Banned', N'ApplicationRole')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
