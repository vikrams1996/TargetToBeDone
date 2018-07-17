namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'939e209a-61f5-4459-9836-9bdbb9060a82', N'admin@gmail.com', 0, N'AEscBjcbzZYC7Y7mcKSAOjTWWpZd9viNX5B47yLTL0Z1hnZUXc96loQDLtRtpDRQSg==', N'c03a3f23-94a9-4c49-a457-a7349d9cfff2', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ef3d11c0-5fa9-4e6d-92ae-5c4a618cf367', N'guest@gmail.com', 0, N'AM2TDuK3XZog6yhy5Cts2jaVkfRbpC+fMJwmRI//fl1rkr5TKslINJZl3XbrXIfnJw==', N'96abe5c5-a51f-481b-abde-b1e500b5acfa', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'46b61591-194d-4518-9c57-b0f37f7155cc', N'CanManageLeaseStatus')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'939e209a-61f5-4459-9836-9bdbb9060a82', N'46b61591-194d-4518-9c57-b0f37f7155cc')

");
        }
        
        public override void Down()
        {
        }
    }
}
