namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd0e7a6fa-3962-4a64-8cbc-98bec67b1492', N'admin@car.com', 0, N'AKdKPin/TjQhTFUQ/GBNvq+vKRtAyFIjydc3cRI8TS9BnL5rgabYy7lW49u4Xr5oDA==', N'cd175ca4-096c-4adc-a1de-af0231488f38', N'444333222', 0, 0, NULL, 1, 0, N'admin@car.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5de31d64-8d32-43e1-998f-cc1a4f55a148', N'gosc@car.com', 0, N'ANhlWqv8UnLJk7nzIvRv1wpaYa8pO3i612WstjyTlON7no+7+Xb13g8Px6hIos0hsA==', N'763516d8-9f72-4a69-b1ba-3041dc86fe24', N'111222333', 0, 0, NULL, 1, 0, N'gosc@car.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'53457156-6b4a-4185-9c71-7ed38a21924f', N'CanManageCars')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd0e7a6fa-3962-4a64-8cbc-98bec67b1492', N'53457156-6b4a-4185-9c71-7ed38a21924f')

");
        }

        public override void Down()
        {
        }
    }
}
