using HelpMeCanada.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HelpMeCanada.Maping
{
    public class ArticleCategoryMap : EntityTypeConfiguration<ArticleCategory> 
    {
        public ArticleCategoryMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(100);
             HasOptional(c => c.ArticleCategory2).WithMany(o => o.ArticleCategory_ParentIds).HasForeignKey(o => o.ParentId);
             ToTable("ArticleCategory");
 

        }
    }
}
