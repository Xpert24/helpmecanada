using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpMeCanada.Models
{
    public class ApplicationUser
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Username")] 
        public string Username { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Password")] 
        public string Password { get; set; }
        public virtual ICollection<RoleUser> RoleUser_UserIds { get; set; }
        public virtual ICollection<MenuPermission> MenuPermission_UserIds { get; set; }
        public virtual ICollection<Item> Item_AddedBys { get; set; }
        public virtual ICollection<Question> Question_UserIds { get; set; }

    }
}
