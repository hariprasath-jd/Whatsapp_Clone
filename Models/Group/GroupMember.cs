using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Whatsapp_clone.Models.User;

namespace Whatsapp_clone.Models.Group
{
    public class GroupMember
    {
        [Key]
        public int GroupMemberId { get; set; }

        public IEnumerable<UserLogin> MemberName { get; set; }


        [ForeignKey("GroupDetails")]
        public int GroupId { get; set; }
        public GroupDetails GroupDetails { get; set; }
    }
}