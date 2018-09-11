using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpMeCanada.Models
{
    public class Item
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Item Category")]
        public int? ItemCategoryId { get; set; }
        public virtual ItemCategory ItemCategory_ItemCategoryId { get; set; }
        [Required]
        [DisplayName("Item Type")]
        public int? ItemTypeId { get; set; }
        public virtual ItemType ItemType_ItemTypeId { get; set; }
        [DisplayName("Added By")]
        public Nullable<int> AddedBy { get; set; }
        public virtual ApplicationUser ApplicationUser_AddedBy { get; set; }
        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Modified By")]
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Date Modied")]
        public Nullable<DateTime> DateModied { get; set; }
        [Required]
        [DisplayName("Deal Closed")]
        public bool DealClosed { get; set; }
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [StringLength(50)]
        [DisplayName("Email")]

        public string Email { get; set; }
        [StringLength(20)]
        [DisplayName("Phone")]
        public string Phone { get; set; }

    }
}
