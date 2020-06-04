﻿namespace CarRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCars : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Cars] ON
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (23, N'Land Cruiser 200', NULL, N'AA0000AA', N'2019', 55, 5, 1, 1, 0, 77, 1, 1, 3, 7, 12, N'/Files/Cars/3a4feee0-0628-4105-bf72-a77ef5c24791.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (24, N'Fortuner', NULL, N'AA0000BB', N'2019', 45, 5, 1, 1, 0, 77, 2, 1, 3, 7, 12, N'/Files/Cars/0de85ffa-ee84-4fe0-9d05-007aa0b6890f.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (25, N'Fortuner', NULL, N'AX2089BI', N'2019', 56, 5, 1, 1, 0, 77, 2, 1, 3, 7, 7, N'/Files/Cars/ab638c93-0992-4efa-9a6a-cf25d87bae22.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (26, N'Oktavia', NULL, N'AA5364KB', N'2019', 40, 4, 1, 1, 0, 79, 1, 1, 1, 4, 1, N'/Files/Cars/a5f31aab-ed44-4ded-9a10-13d45d900656.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (27, N'Oktavia Wagon', NULL, N'AA0044KK', N'2018', 45, 4, 1, 1, 0, 79, 1, 1, 1, 4, 4, N'/Files/Cars/ce77a1a3-0488-4f80-bd55-7ce2a94edf94.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (28, N'Rapid', NULL, N'DD7867GG', N'2017', 35, 4, 1, 1, 0, 79, 1, 2, 1, 3, 1, N'/Files/Cars/46537845-3887-4480-9d36-8d8f97ad5f97.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (29, N'Rapid', NULL, N'AA9821BA', N'2017', 23, 4, 0, 1, 0, 79, 1, 2, 1, 3, 4, N'/Files/Cars/4b0ff3a3-bbb6-4425-af6a-81a23d591fa3.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (30, N'Rapid', NULL, N'CA4325BM', N'2017', 43, 4, 0, 1, 0, 79, 1, 2, 1, 3, 1, N'/Files/Cars/665cb005-cdc8-4509-963e-2269b09bd2e1.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (31, N'Oktavia Wagon', NULL, N'AM3657HH', N'2019', 45, 4, 1, 1, 0, 79, 1, 1, 1, 4, 4, N'/Files/Cars/63a6454f-5a57-4518-9da1-c59c3b0d9a7d.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (32, N'Oktavia', NULL, N'MB7483AB', N'2016', 37, 4, 0, 1, 0, 79, 1, 1, 1, 3, 1, N'/Files/Cars/0a3b9369-d057-422b-a15a-243f81fec8eb.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (33, N'XC 60', NULL, N'BM7463DD', N'2017', 50, 5, 1, 1, 0, 81, 2, 1, 3, 7, 8, N'/Files/Cars/ae6c8c2e-4d41-43e5-a1e2-527f26271c1e.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (34, N'XC 70', NULL, N'KM4583HH', N'2015', 32, 5, 0, 1, 0, 81, 2, 2, 2, 4, 4, N'/Files/Cars/e891887a-e4ec-4b1b-87df-11eec00ac187.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (35, N'XC 90', NULL, N'BM3746AA', N'2018', 56, 5, 0, 1, 0, 81, 1, 1, 3, 7, 12, N'/Files/Cars/b2b4c396-73d3-48a2-91ce-e2c50274d312.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (36, N'XC 90', NULL, N'MB2736BN', N'2018', 54, 5, 0, 1, 0, 81, 1, 1, 3, 7, 12, N'/Files/Cars/68ca2aa2-aec6-4094-a783-9e660d039cee.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (37, N'Camry', NULL, N'AA9999AA', N'2019', 43, 4, 1, 1, 0, 77, 1, 1, 1, 4, 1, N'/Files/Cars/17cab5fb-4771-4c13-af27-8ef8e5b1cce3.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (38, N'Corolla', NULL, N'AB8473MM', N'2019', 34, 4, 1, 1, 0, 77, 1, 1, 1, 3, 1, N'/Files/Cars/38425b3d-3b99-4e33-8548-78b7d4488141.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (39, N'Rapid', NULL, N'AA0009BB', N'2018', 34, 4, 0, 1, 0, 79, 1, 1, 1, 3, 1, N'/Files/Cars/2db5e384-8b96-4f73-a965-4b4ef79b6ed5.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (40, N'M2 Competition', NULL, N'AA1111AA', N'2019', 89, 4, 1, 1, 0, 82, 1, 1, 3, 9, 3, N'/Files/Cars/8b9cc990-d60a-4e89-a5af-69a975fdaca1.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (41, N'M3', NULL, N'II9873HA', N'2016', 56, 4, 1, 1, 0, 82, 1, 1, 2, 3, 1, N'/Files/Cars/346375e0-9fc2-4b44-a5f1-6a17c2424621.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (42, N'X7', NULL, N'AA8888AA', N'2019', 98, 7, 1, 1, 0, 82, 1, 1, 3, 7, 12, N'/Files/Cars/4d5d254b-13f3-4997-9d0e-67ec22e778c3.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (43, N'M3', NULL, N'BB4765', N'2017', 48, 4, 0, 1, 0, 82, 1, 1, 2, 3, 1, N'/Files/Cars/2c68438c-ba31-4542-a5bc-afea97f48062.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (44, N'M5', NULL, N'AA3333AA', N'2018', 87, 4, 1, 1, 0, 82, 1, 1, 3, 5, 1, N'/Files/Cars/bd3fc764-a80b-4137-bb35-64c7828f8db2.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (45, N'i8', NULL, N'AA8765BB', N'2014', 175, 2, 1, 1, 0, 82, 5, 1, 3, 9, 3, N'/Files/Cars/d460ccc3-d0a6-4623-91fa-7e327bdd8f83.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (46, N'i8', NULL, N'MM8787AA', N'2016', 210, 2, 1, 1, 0, 82, 5, 1, 3, 9, 5, N'/Files/Cars/9ce09122-8d68-4d19-ad05-4ca3e267a8f2.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (47, N'M2', NULL, N'KA0228XA', N'2017', 64, 4, 1, 1, 0, 82, 1, 1, 2, 9, 3, N'/Files/Cars/f53284b5-baef-471a-a655-98aec44419c2.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (48, N'M4', NULL, N'MM7463AA', N'2016', 78, 4, 1, 1, 0, 82, 1, 1, 2, 4, 5, N'/Files/Cars/33755dc3-6322-4127-84c3-32620ff32e13.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (49, N'M4', NULL, N'MA5436CA', N'2019', 98, 4, 1, 1, 0, 82, 1, 1, 3, 6, 5, N'/Files/Cars/364d6715-9675-4689-bb9e-9be9c3936167.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (50, N'M4', NULL, N'HH4783KK', N'2016', 76, 4, 1, 1, 0, 82, 1, 1, 3, 4, 3, N'/Files/Cars/67040b75-4e9f-484f-adfd-ccd580c79eb6.png')
                INSERT INTO [dbo].[Cars] ([Id], [Name], [Description], [LicensePlate], [ProductionYear], [PricePerDay], [NumberOfSeats], [WithAirConditioning], [IsAvailable], [IsDeleted], [ManufacturerId], [FuelTypeId], [GearboxTypeId], [TransmissionTypeId], [CarClassId], [BodyTypeId], [PictureLink]) VALUES (51, N'X5', NULL, N'BM6666BM', N'2018', 76, 5, 1, 1, 0, 82, 1, 1, 3, 7, 12, N'/Files/Cars/737f8c27-12ac-4553-8780-800868ac343a.png')
                SET IDENTITY_INSERT [dbo].[Cars] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
