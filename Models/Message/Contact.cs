using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsapp_clone.Models.Message
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime day { get; set; }
    }
}