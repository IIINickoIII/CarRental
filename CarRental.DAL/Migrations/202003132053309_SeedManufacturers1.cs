namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedManufacturers1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            SET IDENTITY_INSERT [dbo].[Manufacturers] ON
            INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [Description], [Country], [IsDeleted], [PictureLink]) VALUES (77, N'Toyota', NULL, N'Japan', 0, N'/Files/Logo/fa598246-5826-4900-9c62-03da07a65c59.png')
            INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [Description], [Country], [IsDeleted], [PictureLink]) VALUES (79, N'Skoda', NULL, N'Chech', 0, N'/Files/Logo/809620d9-07a5-42b6-9ae0-55ec2eb67e6c.png')
            INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [Description], [Country], [IsDeleted], [PictureLink]) VALUES (80, N'Mercedes', NULL, N'Germany', 0, N'/Files/Logo/ad512934-ad15-4169-9489-fbc5436e377e.png')
            INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [Description], [Country], [IsDeleted], [PictureLink]) VALUES (81, N'Volvo', NULL, N'Sweden', 0, N'/Files/Logo/8b93a206-21ef-4273-91ce-017cf7d871ce.png')
            INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [Description], [Country], [IsDeleted], [PictureLink]) VALUES (82, N'BMW', NULL, N'Germany', 0, N'/Files/Logo/ffafada5-dae3-4db0-8507-914664d3c024.png')
            INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [Description], [Country], [IsDeleted], [PictureLink]) VALUES (83, N'Honda', NULL, N'Japan', 0, N'/Files/Logo/615e0b22-5941-4e28-97c0-4feef703bd98.png')
            SET IDENTITY_INSERT [dbo].[Manufacturers] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
