using HelpMeCanada.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HelpMeCanada.Maping
{
    public class ReplyMap : EntityTypeConfiguration<Reply> 
    {
        public ReplyMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Description);
             HasRequired(c => c.Question_QuestionId).WithMany(o => o.Reply_QuestionIds).HasForeignKey(o => o.QuestionId).WillCascadeOnDelete(false);
             HasOptional(c => c.Reply2).WithMany(o => o.Reply_ParentIds).HasForeignKey(o => o.ParentId);
             ToTable("Reply");
 

        }
    }
}
