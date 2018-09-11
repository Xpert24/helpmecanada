namespace HelpMeCanada.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HelpMeCanada.Models.SIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HelpMeCanada.Models.SIContext context)
        {
             string query = string.Format(@"if not exists(select * from [Menu])
begin 
declare @RoleM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Role','Role',NULL) SET @RoleM= (SELECT SCOPE_IDENTITY())
declare @2 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridRole','Role/Index',@RoleM) SET @2= (SELECT SCOPE_IDENTITY())
declare @3 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Role','Role/Create',@RoleM) SET @3= (SELECT SCOPE_IDENTITY())
declare @ApplicationUserM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('ApplicationUser','ApplicationUser',NULL) SET @ApplicationUserM= (SELECT SCOPE_IDENTITY())
declare @5 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridApplication User','ApplicationUser/Index',@ApplicationUserM) SET @5= (SELECT SCOPE_IDENTITY())
declare @6 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Application User','ApplicationUser/Create',@ApplicationUserM) SET @6= (SELECT SCOPE_IDENTITY())
declare @RoleUserM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('RoleUser','RoleUser',NULL) SET @RoleUserM= (SELECT SCOPE_IDENTITY())
declare @8 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridRole User','RoleUser/Index',@RoleUserM) SET @8= (SELECT SCOPE_IDENTITY())
declare @9 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Role User','RoleUser/Create',@RoleUserM) SET @9= (SELECT SCOPE_IDENTITY())
declare @MenuM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Menu','Menu',NULL) SET @MenuM= (SELECT SCOPE_IDENTITY())
declare @11 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridMenu','Menu/Index',@MenuM) SET @11= (SELECT SCOPE_IDENTITY())
declare @12 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Menu','Menu/Create',@MenuM) SET @12= (SELECT SCOPE_IDENTITY())
declare @MenuPermissionM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('MenuPermission','MenuPermission',NULL) SET @MenuPermissionM= (SELECT SCOPE_IDENTITY())
declare @14 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridMenu Permission','MenuPermission/Index',@MenuPermissionM) SET @14= (SELECT SCOPE_IDENTITY())
declare @15 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Menu Permission','MenuPermission/Create',@MenuPermissionM) SET @15= (SELECT SCOPE_IDENTITY())
declare @ArticleCategoryM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('ArticleCategory','ArticleCategory',NULL) SET @ArticleCategoryM= (SELECT SCOPE_IDENTITY())
declare @17 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridArticle Category','ArticleCategory/Index',@ArticleCategoryM) SET @17= (SELECT SCOPE_IDENTITY())
declare @18 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Article Category','ArticleCategory/Create',@ArticleCategoryM) SET @18= (SELECT SCOPE_IDENTITY())
declare @AticlesM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Aticles','Aticles',NULL) SET @AticlesM= (SELECT SCOPE_IDENTITY())
declare @20 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridAticles','Aticles/Index',@AticlesM) SET @20= (SELECT SCOPE_IDENTITY())
declare @21 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Aticles','Aticles/Create',@AticlesM) SET @21= (SELECT SCOPE_IDENTITY())
declare @ItemCategoryM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('ItemCategory','ItemCategory',NULL) SET @ItemCategoryM= (SELECT SCOPE_IDENTITY())
declare @23 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridItem Category','ItemCategory/Index',@ItemCategoryM) SET @23= (SELECT SCOPE_IDENTITY())
declare @24 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Item Category','ItemCategory/Create',@ItemCategoryM) SET @24= (SELECT SCOPE_IDENTITY())
declare @ItemTypeM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('ItemType','ItemType',NULL) SET @ItemTypeM= (SELECT SCOPE_IDENTITY())
declare @26 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridItem Type','ItemType/Index',@ItemTypeM) SET @26= (SELECT SCOPE_IDENTITY())
declare @27 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Item Type','ItemType/Create',@ItemTypeM) SET @27= (SELECT SCOPE_IDENTITY())
declare @ItemM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Item','Item',NULL) SET @ItemM= (SELECT SCOPE_IDENTITY())
declare @29 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridItem','Item/Index',@ItemM) SET @29= (SELECT SCOPE_IDENTITY())
declare @30 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Item','Item/Create',@ItemM) SET @30= (SELECT SCOPE_IDENTITY())
declare @QuestionM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Question','Question',NULL) SET @QuestionM= (SELECT SCOPE_IDENTITY())
declare @32 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridQuestion','Question/Index',@QuestionM) SET @32= (SELECT SCOPE_IDENTITY())
declare @33 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Question','Question/Create',@QuestionM) SET @33= (SELECT SCOPE_IDENTITY())
declare @QuestionCategoryM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('QuestionCategory','QuestionCategory',NULL) SET @QuestionCategoryM= (SELECT SCOPE_IDENTITY())
declare @35 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridQuestion Category','QuestionCategory/Index',@QuestionCategoryM) SET @35= (SELECT SCOPE_IDENTITY())
declare @36 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Question Category','QuestionCategory/Create',@QuestionCategoryM) SET @36= (SELECT SCOPE_IDENTITY())
declare @ReplyM int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Reply','Reply',NULL) SET @ReplyM= (SELECT SCOPE_IDENTITY())
declare @38 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('List GridReply','Reply/Index',@ReplyM) SET @38= (SELECT SCOPE_IDENTITY())
declare @39 int=null
insert into Menu (MenuText,MenuURL,ParentId) values('Add Reply','Reply/Create',@ReplyM) SET @39= (SELECT SCOPE_IDENTITY())
declare @rolew int=null
insert into Role (RoleName,IsActive) values('Admin',1) SET @rolew= (SELECT SCOPE_IDENTITY())
end
"); context.Database.ExecuteSqlCommand(query);
        }
    }
}
