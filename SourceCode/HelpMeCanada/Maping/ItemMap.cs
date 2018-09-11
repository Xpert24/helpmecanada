using HelpMeCanada.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HelpMeCanada.Maping
{
    public class ItemMap : EntityTypeConfiguration<Item> 
    {
        public ItemMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(100);
             Property(o => o.Description);
             HasRequired(c => c.ItemCategory_ItemCategoryId).WithMany(o => o.Item_ItemCategoryIds).HasForeignKey(o => o.ItemCategoryId).WillCascadeOnDelete(false);
             HasRequired(c => c.ItemType_ItemTypeId).WithMany(o => o.Item_ItemTypeIds).HasForeignKey(o => o.ItemTypeId).WillCascadeOnDelete(false);
             Property(o => o.Email).HasMaxLength(50);
             Property(o => o.Phone).HasMaxLength(20);
             ToTable("Item");
 

        }
    }
}
