using BusinessLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YİPABlogMVC.Controllers
{
    public class HomeController : Controller
    {
        AboutManager _aboutManager = new AboutManager();
        SocialMediaManager _socialMediaManager = new SocialMediaManager();
   
        //[Route("anasayfa")]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Header()
        {
            return PartialView();
        }
        

        public PartialViewResult MainPageAbout()
        {
            var aboutList = _aboutManager.GetAll();
            return PartialView(aboutList);
        }

        public PartialViewResult Footer()
        {
            
            return PartialView();
        }

        public PartialViewResult SocialMediaList() 
        {
            var socialMediaList = _socialMediaManager.GetAll();
            return PartialView(socialMediaList);
        }


    }
}