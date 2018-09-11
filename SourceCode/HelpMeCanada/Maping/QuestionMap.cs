using HelpMeCanada.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HelpMeCanada.Maping
{
    public class QuestionMap : EntityTypeConfiguration<Question> 
    {
        public QuestionMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(100);
             Property(o => o.Desciption);
             HasRequired(c => c.ApplicationUser_UserId).WithMany(o => o.Question_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(false);
             HasRequired(c => c.QuestionCategory_QuestionCategoryId).WithMany(o => o.Question_QuestionCategoryIds).HasForeignKey(o => o.QuestionCategoryId).WillCascadeOnDelete(false);
             ToTable("Question");
 

        }
    }
}
