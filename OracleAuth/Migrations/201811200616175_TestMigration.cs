namespace OracleAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ADMIN.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "ADMIN.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("ADMIN.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("ADMIN.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "ADMIN.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Decimal(nullable: false, precision: 1, scale: 0),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Decimal(nullable: false, precision: 1, scale: 0),
                        TwoFactorEnabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        AccessFailedCount = c.Decimal(nullable: false, precision: 10, scale: 0),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "ADMIN.AspNetUserClaims",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMIN.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "ADMIN.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("ADMIN.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ADMIN.AspNetUserRoles", "UserId", "ADMIN.AspNetUsers");
            DropForeignKey("ADMIN.AspNetUserLogins", "UserId", "ADMIN.AspNetUsers");
            DropForeignKey("ADMIN.AspNetUserClaims", "UserId", "ADMIN.AspNetUsers");
            DropForeignKey("ADMIN.AspNetUserRoles", "RoleId", "ADMIN.AspNetRoles");
            DropIndex("ADMIN.AspNetUserLogins", new[] { "UserId" });
            DropIndex("ADMIN.AspNetUserClaims", new[] { "UserId" });
            DropIndex("ADMIN.AspNetUsers", "UserNameIndex");
            DropIndex("ADMIN.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("ADMIN.AspNetUserRoles", new[] { "UserId" });
            DropIndex("ADMIN.AspNetRoles", "RoleNameIndex");
            DropTable("ADMIN.AspNetUserLogins");
            DropTable("ADMIN.AspNetUserClaims");
            DropTable("ADMIN.AspNetUsers");
            DropTable("ADMIN.AspNetUserRoles");
            DropTable("ADMIN.AspNetRoles");
        }
    }
}
