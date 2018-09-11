using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpMeCanada.Models
{
    public class ItemCategory
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [DisplayName("Parent")] 
        public Nullable<int> ParentId { get; set; }
        public virtual ItemCategory ItemCategory2 { get; set; }
        public virtual ICollection<ItemCategory> ItemCategory_ParentIds { get; set; }
        public virtual ICollection<Item> Item_ItemCategoryIds { get; set; }

    }
}
