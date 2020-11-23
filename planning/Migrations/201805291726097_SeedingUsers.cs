namespace planning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'69cf9cd1-f48d-4cdd-a541-e64d82e97908', N'guest@plan.com', 0, N'AIumro3Bmut3RRinM5ydBBT2oydR2EpTSbfyUTid68rqZ3u/wShW0XioVHD2VZwBNg==', N'1a74395a-e843-4a1e-aa0c-325669f5476d', NULL, 0, 0, NULL, 1, 0, N'guest@plan.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'de84bee6-d068-4e4b-9702-1d9226f1b026', N'admin@plan.com', 0, N'AOe8sVefNv6afuPVfz1F5p+EOsFRP0lmBPJu7PV2wYkCqGeNCNxsZfijeFLuY0XC6w==', N'8b447f80-60e4-4704-b4e7-b50d67971139', NULL, 0, 0, NULL, 1, 0, N'admin@plan.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'68745b6f-f450-485b-9bc4-f2595044a111', N'CanManage')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'de84bee6-d068-4e4b-9702-1d9226f1b026', N'68745b6f-f450-485b-9bc4-f2595044a111')

");
        }
        
        public override void Down()
        {
        }
    }
}
