using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Whatsapp_clone.Models.User;

namespace Whatsapp_clone.Models.Group
{
    public class GroupDetails
    {
        [Key]
        public int GroupId { get; set; }
        
        public string GroupName { get; set; }

        public ICollection<GroupMember> GroupMembers { get; set; }


        public UserLogin Users { get; set; }
    }
}