using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace YİPABlogMVC.Controllers
{
    
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            Context c = new Context();
            var adminInfo = c.Admins.FirstOrDefault(x => x.Name == p.Name && x.Password == p.Password);
            if (adminInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.Name, false);
                Session["Name"] = adminInfo.Name.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin","Login");
        }
    }
}