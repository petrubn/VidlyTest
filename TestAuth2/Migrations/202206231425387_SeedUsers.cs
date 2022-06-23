namespace TestAuth2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
               INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'75435624-1474-4ee0-a488-ee517d0c53c4', N'guest@vidly.com', 0, N'AFG1hmA+sd2hvB+HmjusGAAkCma2pPLDgDqJhdgLGfX9lL2Jm8DNHLRAGMxifnv6KQ==', N'32eea20c-1697-4124-8717-edf6f2ac5895', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                                                                                                                                                                                                                                        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8c2dd1c5-c7a9-452f-8dcb-c8faaee775f6', N'admin@vidly.com', 0, N'AJIaOcQqiQIbBtndj1jJaJY4vLA8W9g3W76A3e0RdjfKh+HnMB+aCtAVihcIR7duMQ==', N'53972be0-352d-4202-ac1d-f36f252e24db', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                                                                                                                                                                                                                                        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f5294c4c-28a7-4755-90bf-6e1966928893', N'petru@domain.com', 0, N'AJ6Z75DNCCT2ivA8ZHPZ5FUMHqAlPVKV371lqfgJUO/weYAfRWbYtQXmhaFExeYw5A==', N'fcedf549-01a8-4f7b-9308-c98f1ea704b6', NULL, 0, 0, NULL, 1, 0, N'petru@domain.com')

    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b7f7dd97-e65c-4f3b-a726-327a19d925c9', N'CanManageMovies')
            
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8c2dd1c5-c7a9-452f-8dcb-c8faaee775f6', N'b7f7dd97-e65c-4f3b-a726-327a19d925c9')


");
            
            
            
        }

        public override void Down()
        {
            
        }
        
    }
}
