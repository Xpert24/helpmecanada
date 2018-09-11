using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpMeCanada.Models
{
    public class Question
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [Required]
        [DisplayName("Desciption")] 
        public string Desciption { get; set; }
        [Required]
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual ApplicationUser ApplicationUser_UserId { get; set; }
        [Required]
        [DisplayName("Question Category")] 
        public int? QuestionCategoryId { get; set; }
        public virtual QuestionCategory QuestionCategory_QuestionCategoryId { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Modified By")] 
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Date Modied")] 
        public Nullable<DateTime> DateModied { get; set; }
        public virtual ICollection<Reply> Reply_QuestionIds { get; set; }

    }
}
