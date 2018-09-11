using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpMeCanada.Models
{
    public class QuestionCategory
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [DisplayName("Parent")] 
        public Nullable<int> ParentId { get; set; }
        public virtual QuestionCategory QuestionCategory2 { get; set; }
        public virtual ICollection<QuestionCategory> QuestionCategory_ParentIds { get; set; }
        public virtual ICollection<Question> Question_QuestionCategoryIds { get; set; }

    }
}
