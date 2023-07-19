using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whatsapp_clone.Models.Message;

namespace Whatsapp_clone.Controllers
{
    public class HomeController : Controller
    {
        static Models.AppContext appContext = new Models.AppContext();
        string[] dup = new string[(from name in appContext.Details select name.Name).Count()];
        // GET: Home
        public ActionResult Index()
        {
            if (Session["Id"] != null)
            {
                return RedirectToAction("LoadContacts");
            }
            else
            {
                ViewData["UserWarning"] = "";
                ViewData["PasswdWarning"] = "";
                ViewData["click"] = false;
                return PartialView("_ReLoginPartial");

            }
        }

        [Route("Home")]
        public ActionResult LoadContacts()
        {
            int num = 0;
            List<Contact> contacts = new List<Contact>();
            int id = Convert.ToInt32(Session["Id"]);
            var all = (from data in appContext.Messages where data.SenderId == id select data).ToList();
            ViewData["click"] = false;
            foreach (MessageDetails i in all)
            {
                var data = new Contact()
                {
                    Id = i.RecipientId,
                    Name = (from name in appContext.Details where name.Id == i.RecipientId select name.Name).FirstOrDefault(),
                    Content = i.Content,
                    day = i.Timestamp
                };
                if (dup.Contains(data.Name))
                {
                    continue;
                }
                else
                {
                    contacts.Add(data);
                    dup[num] = data.Name;
                    num++;
                }
            }
            if (Session["Id"] != null)
            {
                return View("Index", contacts);
            }
            else
            {
                ViewData["UserWarning"] = "";
                ViewData["PasswdWarning"] = "";
                ViewData["click"] = false;
                return PartialView("_ReLoginPartial");

            }
        }


        [Route("Logout")]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToRoute("");
        }
    }
}