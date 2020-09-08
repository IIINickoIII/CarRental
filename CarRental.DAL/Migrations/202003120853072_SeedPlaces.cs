namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedPlaces : DbMigration
    {
        public override void Up()
        {
            Sql(@"  SET IDENTITY_INSERT [dbo].[Places] ON
                    INSERT INTO [dbo].[Places] ([Id], [Address], [IsDelete], [Description], [Name]) VALUES (1, N'61052, Pryvokzalnaya Square, 1, Kharkiv, Kharkiv', 0, N'Kharkiv Railway Station (Ukrainian: Харків-Пасажирський) is a railway station in Kharkiv, the second largest city in Ukraine.', N'Kharkiv railway station')
                    INSERT INTO [dbo].[Places] ([Id], [Address], [IsDelete], [Description], [Name]) VALUES (2, N'61000, Romashkina Street, 1, Kharkiv, Kharkiv region', 0, N'Kharkiv International Airport (Ukrainian: Міжнародний аеропорт Харків), (IATA: HRK, ICAO: UKHH) is an airport located in Kharkiv, Ukraine. The airport is the main airfield serving the city of Kharkiv, Ukraine''s second largest city. Located to the south-east of the city centre, in the city''s Slobidskyi district.', N'Kharkiv International Airport')
                    INSERT INTO [dbo].[Places] ([Id], [Address], [IsDelete], [Description], [Name]) VALUES (3, N'61000, University Street, 5, Kharkiv, Kharkiv region', 0, N'Kharkov Historical museum was founded in 1920. Modern museum has 4 departments: primitive society, feudalism, capitalism and soviet period. There is rich collection of archeological findings: from settlements of bronze era, of Saltovskiy catacomb burial grounds dated back to VIII-X centuries, set of objects from Donetsk site of ancient settlement. ', N'Kharkov Historical Museum')
                    INSERT INTO [dbo].[Places] ([Id], [Address], [IsDelete], [Description], [Name]) VALUES (4, N'61000, Sumska street, 81, Kharkiv, Kharkiv region,', 0, N'The Central amusement park remains a favorite pastime among families and friends'' companies. Here you will find many attractions for children, for romantic walks and extreme lovers. And many other things.', N'Gorky family park')
                    INSERT INTO [dbo].[Places] ([Id], [Address], [IsDelete], [Description], [Name]) VALUES (5, N'61001, ave. Yuriy Gagarin, 22, Kharkiv, Kharkiv region', 0, N'The bus station is an interesting architectural structure of 3 floors with an arched facade. It is a major transportation hub. A large number of buses pass through it, connecting among themselves other settlements of Ukraine.', N'Bus Station # 1')
                    SET IDENTITY_INSERT [dbo].[Places] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
