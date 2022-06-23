using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YİPABlogMVC.Controllers
{
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager();

        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AboutContent()
        {
            var aboutList = _aboutManager.GetAll();
            return PartialView(aboutList);
        }
    }
}