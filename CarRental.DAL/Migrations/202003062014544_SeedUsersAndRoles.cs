namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7dc90d6d-0ec6-47cd-b733-5ccfacd94e44', N'manager@carrental.com', 0, N'AIFV/OkKypmp5aFE1CGebtUnq0sGVm7MvKhCYo5xGMx+4GOM84nijcSvJwei+SMMWA==', N'7baf3515-3fe4-4871-936d-3545ed3eab4c', NULL, 0, 0, NULL, 0, 0, N'manager@carrental.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'df864b77-f3e7-43a0-a1e3-772f46bc5d8a', N'user@carrental.com', 0, N'AHU4zepVa9Y1c+/QaFt66mBoBQNehYabvKjHeWewhUcOhZRsyZfSraSfWFFvT/LT6Q==', N'67653c95-99a3-4799-abb8-3f48cc28ab2b', NULL, 0, 0, NULL, 0, 0, N'user@carrental.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e83911e0-8e80-41e8-afeb-9a728502337b', N'admin@carrental.com', 0, N'AA8XLbF5TM08J4Hnax5ipkoyvsseoS6ukB5V8DEL5bre6V9cJX3SlvMhdGAOScLMhw==', N'02985f2a-bdec-44ae-a656-3e5de34de851', NULL, 0, 0, NULL, 0, 0, N'admin@carrental.com')             
                INSERT INTO [dbo].[ClientProfiles] ([Id], [Name], [Address]) VALUES (N'7dc90d6d-0ec6-47cd-b733-5ccfacd94e44', N'Alex', N'Ukraine, Kharkov, Heroiv Pratsi St, 12')
                INSERT INTO [dbo].[ClientProfiles] ([Id], [Name], [Address]) VALUES (N'df864b77-f3e7-43a0-a1e3-772f46bc5d8a', N'John', N'Ukraine, Kharkov, 23 Serpnya St., 44')
                INSERT INTO [dbo].[ClientProfiles] ([Id], [Name], [Address]) VALUES (N'e83911e0-8e80-41e8-afeb-9a728502337b', N'Nicko', N'Ukraine, Kharkov, Nauky Ave, 49')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'3531e5f8-dad4-4936-9550-cadd05441c91', N'Manager', N'ApplicationRole')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'4d65bc8d-7c53-47ac-9ad8-5a8cfa0a8ba5', N'Admin', N'ApplicationRole')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'7a136f3f-7868-4601-b95f-7cd153bf6cca', N'User', N'ApplicationRole')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7dc90d6d-0ec6-47cd-b733-5ccfacd94e44', N'3531e5f8-dad4-4936-9550-cadd05441c91')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e83911e0-8e80-41e8-afeb-9a728502337b', N'4d65bc8d-7c53-47ac-9ad8-5a8cfa0a8ba5')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'df864b77-f3e7-43a0-a1e3-772f46bc5d8a', N'7a136f3f-7868-4601-b95f-7cd153bf6cca')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
