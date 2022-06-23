using BusinessLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YİPABlogMVC.Controllers
{
    public class NewsletterController : Controller
    {
        NewsletterManager _newsletterManager = new NewsletterManager();
        // GET: Newsletter
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMail(Newsletter p)
        {
            _newsletterManager.AddNewslterr(p);
            return PartialView();
        }

        
    }
}