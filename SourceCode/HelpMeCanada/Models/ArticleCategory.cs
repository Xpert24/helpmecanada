using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpMeCanada.Models
{
    public class ArticleCategory
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [DisplayName("Parent")] 
        public Nullable<int> ParentId { get; set; }
        public virtual ArticleCategory ArticleCategory2 { get; set; }
        public virtual ICollection<ArticleCategory> ArticleCategory_ParentIds { get; set; }
        public virtual ICollection<Aticles> Aticles_ArticleCategoryIds { get; set; }

    }
}
