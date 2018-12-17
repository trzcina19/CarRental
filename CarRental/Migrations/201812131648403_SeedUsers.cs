namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6e542fb1-48b3-4b3f-bed6-3ca89e4d017e', N'admin@car.com', 0, N'AESrA90WCQON+sNp5ub25BTTz2clrQWdZ1Dec4FXxrXL8FvNSNdxt1A4BLGXBXK12Q==', N'c8058a88-d29f-4b91-bcbc-69a998651a72', NULL, 0, 0, NULL, 1, 0, N'admin@car.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dd53e2af-e552-4e22-b455-f2b2af53b435', N'gosc@car.com', 0, N'ALG1v9UBaNKWzNTNvJdmnBFEGr+pYWqk3NI3SrnxIdYZ/zxk0vwt7eB9MLa+FahTKg==', N'0b0f99e4-f7b0-457d-863e-b6e26e0b86c5', NULL, 0, 0, NULL, 1, 0, N'gosc@car.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'53457156-6b4a-4185-9c71-7ed38a21924f', N'CanManageCars')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6e542fb1-48b3-4b3f-bed6-3ca89e4d017e', N'53457156-6b4a-4185-9c71-7ed38a21924f')

");
        }

        public override void Down()
        {
        }
    }
}
