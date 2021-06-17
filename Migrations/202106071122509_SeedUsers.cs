namespace Vidly_MVCProject.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b2266a6b-c53b-4f1a-878e-fde59f8088f3', N'berkcantezcaner@gmail.com', 0, N'APMn2C+uaW1nYzniWBYmTa4A+kfzjVf5sGtmTex+uKqqQRgdnlZ+mAJZU8xX6T0JaA==', N'3ac9bfd9-c6db-475e-9f2d-c620f4f6343b', NULL, 0, 0, NULL, 1, 0, N'berkcantezcaner@gmail.com')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e20158ba-0fcb-460d-997d-031e2cfc5c06', N'admin@vidly.com', 0, N'AExm85ZRevPnXLDRGmQcoA9hYGsUQmhnojBBNd9iivAzGloUpZAyhUhcY9B2jxSUtA==', N'c7426b12-40c0-4c54-bdcb-39c912f251c8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'eda59a5e-409a-451f-b485-8a9de20420cf', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e20158ba-0fcb-460d-997d-031e2cfc5c06', N'eda59a5e-409a-451f-b485-8a9de20420cf')

");
        }

        public override void Down()
        {
        }
    }
}