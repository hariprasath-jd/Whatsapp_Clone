using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Whatsapp_clone.Models.User;

namespace Whatsapp_clone.Models.Message
{
    public class MessageDetails
    {
        [Key]
        public int MessageId { get; set; }

        public string Content { get; set; }

        [ForeignKey("Sender")]
        public int SenderId { get; set; }
        public UserLogin Sender { get; set; }

        [ForeignKey("Recipient")]
        public int RecipientId { get; set; }
        public UserLogin Recipient { get; set; }

        public DateTime Timestamp { get; set; }


    }
}