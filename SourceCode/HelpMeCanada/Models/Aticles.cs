using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpMeCanada.Models
{
    public class Aticles
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(200)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [Required]
        [DisplayName("Description")] 
        public string Description { get; set; }
        [Required]
        [DisplayName("Article Category")] 
        public int? ArticleCategoryId { get; set; }
        public virtual ArticleCategory ArticleCategory_ArticleCategoryId { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Modified By")] 
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Date Modied")] 
        public Nullable<DateTime> DateModied { get; set; }

    }
}
