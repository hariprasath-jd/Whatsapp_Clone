using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whatsapp_clone.Models.Message;
using Whatsapp_clone.Models;
using System.IO;
using System.Text.RegularExpressions;

namespace Whatsapp_clone.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        static Models.AppContext appContext = new Models.AppContext();

        [HttpPost]
        [Route("FetchChat")]
        public ActionResult LoadChat(int RId)
        {

            List<Messages> result = new List<Messages>();
            int sender = Convert.ToInt32(Session["Id"]);
            int receiver = Convert.ToInt32(Request.QueryString["RId"]);


            var Recived_chat = (from message in appContext.Messages where message.SenderId == sender && message.RecipientId == receiver select message).ToList();
            var Send_chat = (from message in appContext.Messages where message.SenderId == receiver && message.RecipientId == sender select message).ToList();

            Messages rec_data = new Messages()
            {
                time = (from t in Recived_chat select t.Timestamp).ToList(),
                Content = (from r_c in Recived_chat select r_c.Content).ToList(),
                Type = "Received"
            };

            Messages send_data = new Messages()
            {
                time = (from t in Recived_chat select t.Timestamp).ToList(),
                Content = (from r_c in Send_chat select r_c.Content).ToList(),
                Type = "Sent"
            };

            result.Add(rec_data);
            result.Add(send_data);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("SendMessage")]
        public ActionResult SendMessage()
        {
            bool res;
            MessageDetails message = new MessageDetails()
            {
                Timestamp = DateTime.Now,
                RecipientId = Convert.ToInt32(Session["Id"]),
                SenderId = Convert.ToInt32(Request.Form["rec_id"]),
                Content = Request.Form["Content"]
            };
            Debug.WriteLine("from the method");
            appContext.Messages.Add(message);
            int x = appContext.SaveChanges();
            if (x > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("NewChat")]
        public ActionResult NewChat()
        {
            return Json("",JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [Route("SearchContact")]
        public ActionResult SearchContact()
        {
            List<Contact> result = new List<Contact>();
            string data;
            MatchCollection matches;


            using (var reader = new StreamReader(Request.InputStream))
            {
                data = reader.ReadToEnd();
            }
            var numbers = (from table in appContext.Details select new Contact { Content = table.Email, Name = table.Name }).ToArray();

            if (data != "" && data != " ")
            {
                foreach (Contact i in numbers)
                {
                    matches = Regex.Matches(i.Content.Replace("@[a-zA-Z0-9][a-zA-Z0-9.-]+(.[a-z]{2,}|.[0-9]{1,}", " "), data);
                    foreach (Match match in matches)
                    {
                        if (result.Contains(i))
                        {
                            continue;
                        }
                        else
                        {
                            result.Add(i);
                        }
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result.Add(new Contact { Name = "No Contact Found", Content = "..." });
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
