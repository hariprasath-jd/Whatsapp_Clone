using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatsapp_clone.Models.User
{
    public class UserDetails
    {
        [Key]
        [ForeignKey("Login")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        public UserLogin Login { get; set; }
    }
}