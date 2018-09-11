using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpMeCanada.Models
{
    public class MenuPermission
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [DisplayName("Menu")] 
        public int? MenuId { get; set; }
        public virtual Menu Menu_MenuId { get; set; }
        [Required]
        [DisplayName("Role")] 
        public int? RoleId { get; set; }
        public virtual Role Role_RoleId { get; set; }
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual ApplicationUser ApplicationUser_UserId { get; set; }

    }
}
