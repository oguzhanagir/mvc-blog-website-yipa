using BusinessLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YİPABlogMVC.Controllers
{
    public class ContactController : Controller
    {
        ContactManager _contactManager = new ContactManager();
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact p)
        {
            p.MessageDate = DateTime.Now;
            _contactManager.AddContact(p);
            return RedirectToAction("Index","Contact");
        }

        public PartialViewResult ContactInfo()
        {
            return PartialView();
        }


      

    }
}