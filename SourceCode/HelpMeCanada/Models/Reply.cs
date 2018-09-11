using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpMeCanada.Models
{
    public class Reply
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Description")] 
        public string Description { get; set; }
        [Required]
        [DisplayName("Question")] 
        public int? QuestionId { get; set; }
        public virtual Question Question_QuestionId { get; set; }
        [DisplayName("Parent")] 
        public Nullable<int> ParentId { get; set; }
        public virtual Reply Reply2 { get; set; }
        [Required]
        [DisplayName("Is Heplfull")] 
        public bool IsHeplfull { get; set; }
        public virtual ICollection<Reply> Reply_ParentIds { get; set; }

    }
}
