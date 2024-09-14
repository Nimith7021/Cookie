using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["VisitCount"];
            if (cookie != null)
            {
                int count = int.Parse(cookie.Value) + 1;
                cookie.Value = count.ToString();
                Response.Cookies.Add(cookie);
                ViewBag.Count = count;
                return View();
            }
            else
            {
                cookie = new HttpCookie("VisitCount", "1");
                cookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(cookie);
                return View();
            }
        }

        public ActionResult DisplayPage()
        {
            return View();
        }
    }
}