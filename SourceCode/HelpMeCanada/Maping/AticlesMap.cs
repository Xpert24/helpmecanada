using HelpMeCanada.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HelpMeCanada.Maping
{
    public class AticlesMap : EntityTypeConfiguration<Aticles> 
    {
        public AticlesMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(200);
             Property(o => o.Description);
             HasRequired(c => c.ArticleCategory_ArticleCategoryId).WithMany(o => o.Aticles_ArticleCategoryIds).HasForeignKey(o => o.ArticleCategoryId).WillCascadeOnDelete(false);
             ToTable("Aticles");
 

        }
    }
}
