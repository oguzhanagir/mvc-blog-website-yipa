using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YİPABlogMVC.Controllers
{
    public class HomeController : Controller
    {
        BlogManager _blogManager = new BlogManager();
   

        //[Route("anasayfa")]
        public ActionResult Index()
        {
            return View();
        }

        

        public PartialViewResult Services()
        {
            return PartialView();
        }

        public PartialViewResult MainPageAbout()
        {
            return PartialView();
        }

        public PartialViewResult Newsletter()
        {
            return PartialView();
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }


    }
}