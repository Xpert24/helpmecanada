using HelpMeCanada.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HelpMeCanada.Models
{
    public class SIContext : DbContext
    {
        public SIContext()
            : base("name=SIConnectionString")
        {
        }

         
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public virtual DbSet<RoleUser> RoleUsers { get; set; }
		public virtual DbSet<Menu> Menus { get; set; }
		public virtual DbSet<MenuPermission> MenuPermissions { get; set; }
		public virtual DbSet<ArticleCategory> ArticleCategorys { get; set; }
		public virtual DbSet<Aticles> Aticless { get; set; }
		public virtual DbSet<ItemCategory> ItemCategorys { get; set; }
		public virtual DbSet<ItemType> ItemTypes { get; set; }
		public virtual DbSet<Item> Items { get; set; }
		public virtual DbSet<Question> Questions { get; set; }
		public virtual DbSet<QuestionCategory> QuestionCategorys { get; set; }
		public virtual DbSet<Reply> Replys { get; set; }

        

        //
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.RoleMap());
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.ApplicationUserMap());
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.RoleUserMap());
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.MenuMap());
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.MenuPermissionMap());
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.ArticleCategoryMap());
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.AticlesMap());
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.ItemCategoryMap());
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.ItemTypeMap());
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.ItemMap());
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.QuestionMap());
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.QuestionCategoryMap());
			modelBuilder.Configurations.Add(new HelpMeCanada.Maping.ReplyMap());


            base.OnModelCreating(modelBuilder);
        }
        //
    }
}
 
