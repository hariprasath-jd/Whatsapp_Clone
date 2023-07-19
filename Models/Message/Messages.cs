using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsapp_clone.Models.Message
{
    public class Messages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Content { get; set; }
        public List<DateTime> time { get; set; }
        public string Type { get; set; }
    }
}