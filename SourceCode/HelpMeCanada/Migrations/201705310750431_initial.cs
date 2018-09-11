namespace HelpMeCanada.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        ItemCategoryId = c.Int(nullable: false),
                        ItemTypeId = c.Int(nullable: false),
                        AddedBy = c.Int(),
                        DateAdded = c.DateTime(),
                        ModifiedBy = c.Int(),
                        DateModied = c.DateTime(),
                        DealClosed = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        ApplicationUser_AddedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_AddedBy_Id)
                .ForeignKey("dbo.ItemCategory", t => t.ItemCategoryId)
                .ForeignKey("dbo.ItemType", t => t.ItemTypeId)
                .Index(t => t.ApplicationUser_AddedBy_Id)
                .Index(t => t.ItemCategoryId)
                .Index(t => t.ItemTypeId);
            
            CreateTable(
                "dbo.ItemCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategory", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.ItemType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuPermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .ForeignKey("dbo.Menu", t => t.MenuId)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MenuId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuText = c.String(nullable: false, maxLength: 100),
                        MenuURL = c.String(nullable: false, maxLength: 400),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Desciption = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        QuestionCategoryId = c.Int(nullable: false),
                        AddedBy = c.Int(),
                        DateAdded = c.DateTime(),
                        ModifiedBy = c.Int(),
                        DateModied = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .ForeignKey("dbo.QuestionCategory", t => t.QuestionCategoryId)
                .Index(t => t.UserId)
                .Index(t => t.QuestionCategoryId);
            
            CreateTable(
                "dbo.QuestionCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionCategory", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        ParentId = c.Int(),
                        IsHeplfull = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .ForeignKey("dbo.Reply", t => t.ParentId)
                .Index(t => t.QuestionId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.ArticleCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleCategory", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Aticles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false),
                        ArticleCategoryId = c.Int(nullable: false),
                        AddedBy = c.Int(),
                        DateAdded = c.DateTime(),
                        ModifiedBy = c.Int(),
                        DateModied = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleCategory", t => t.ArticleCategoryId)
                .Index(t => t.ArticleCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aticles", "ArticleCategoryId", "dbo.ArticleCategory");
            DropForeignKey("dbo.ArticleCategory", "ParentId", "dbo.ArticleCategory");
            DropForeignKey("dbo.Reply", "ParentId", "dbo.Reply");
            DropForeignKey("dbo.Reply", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Question", "QuestionCategoryId", "dbo.QuestionCategory");
            DropForeignKey("dbo.QuestionCategory", "ParentId", "dbo.QuestionCategory");
            DropForeignKey("dbo.Question", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.MenuPermission", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleUser", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleUser", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.MenuPermission", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.Menu", "ParentId", "dbo.Menu");
            DropForeignKey("dbo.MenuPermission", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Item", "ItemTypeId", "dbo.ItemType");
            DropForeignKey("dbo.Item", "ItemCategoryId", "dbo.ItemCategory");
            DropForeignKey("dbo.ItemCategory", "ParentId", "dbo.ItemCategory");
            DropForeignKey("dbo.Item", "ApplicationUser_AddedBy_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Aticles", new[] { "ArticleCategoryId" });
            DropIndex("dbo.ArticleCategory", new[] { "ParentId" });
            DropIndex("dbo.Reply", new[] { "ParentId" });
            DropIndex("dbo.Reply", new[] { "QuestionId" });
            DropIndex("dbo.Question", new[] { "QuestionCategoryId" });
            DropIndex("dbo.QuestionCategory", new[] { "ParentId" });
            DropIndex("dbo.Question", new[] { "UserId" });
            DropIndex("dbo.MenuPermission", new[] { "RoleId" });
            DropIndex("dbo.RoleUser", new[] { "RoleId" });
            DropIndex("dbo.RoleUser", new[] { "UserId" });
            DropIndex("dbo.MenuPermission", new[] { "MenuId" });
            DropIndex("dbo.Menu", new[] { "ParentId" });
            DropIndex("dbo.MenuPermission", new[] { "UserId" });
            DropIndex("dbo.Item", new[] { "ItemTypeId" });
            DropIndex("dbo.Item", new[] { "ItemCategoryId" });
            DropIndex("dbo.ItemCategory", new[] { "ParentId" });
            DropIndex("dbo.Item", new[] { "ApplicationUser_AddedBy_Id" });
            DropTable("dbo.Aticles");
            DropTable("dbo.ArticleCategory");
            DropTable("dbo.Reply");
            DropTable("dbo.QuestionCategory");
            DropTable("dbo.Question");
            DropTable("dbo.RoleUser");
            DropTable("dbo.Role");
            DropTable("dbo.Menu");
            DropTable("dbo.MenuPermission");
            DropTable("dbo.ItemType");
            DropTable("dbo.ItemCategory");
            DropTable("dbo.Item");
            DropTable("dbo.ApplicationUser");
        }
    }
}
