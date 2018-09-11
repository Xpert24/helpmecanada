using HelpMeCanada.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HelpMeCanada.Maping
{
    public class ApplicationUserMap : EntityTypeConfiguration<ApplicationUser> 
    {
        public ApplicationUserMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Username).HasMaxLength(100);
             Property(o => o.Password).HasMaxLength(100);
             ToTable("ApplicationUser");
 

        }
    }
}
