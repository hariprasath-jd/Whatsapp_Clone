using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using Whatsapp_clone.Models.Message;
using Whatsapp_clone.Models.User;

namespace Whatsapp_clone.Controllers
{
    public class LoginController : Controller
    {
        static Models.AppContext appContext = new Models.AppContext();
        // GET: Login
        [Route]
        public ActionResult Index()
        {
            ViewData["UserWarning"] = "";
            ViewData["PasswdWarning"] = "";
            return View();
        }

        [Route("Validate")]
        public ActionResult Validate(FormCollection form)
        {
            string Userid = form["UserName"];
            string passwd = form["PassWord"];

            try
            {
                UserLogin li = (from name in appContext.Logins where name.UserName == Userid select name).First();


                if (li.Password == passwd)
                {
                    Session["Id"] = li.Id;
                    return RedirectToRoute("HomePage");

                }
                else
                {
                    ViewData["UserWarning"] = "";
                    ViewData["PasswdWarning"] = "Password Didn't Match";
                    return View("Index");
                }
            }


            catch (Exception)
            {
                ViewData["UserWarning"] = "User Not Found*";
                ViewData["PasswdWarning"] = "";
                return View("Index");
            }

        }
    }
}