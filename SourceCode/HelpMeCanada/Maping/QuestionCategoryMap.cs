using HelpMeCanada.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HelpMeCanada.Maping
{
    public class QuestionCategoryMap : EntityTypeConfiguration<QuestionCategory> 
    {
        public QuestionCategoryMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(100);
             HasOptional(c => c.QuestionCategory2).WithMany(o => o.QuestionCategory_ParentIds).HasForeignKey(o => o.ParentId);
             ToTable("QuestionCategory");
 

        }
    }
}
