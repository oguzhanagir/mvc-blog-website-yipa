using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YİPABlogMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //Blog Start
        public PartialViewResult BlogList()
        {
            return PartialView();
        }

        public PartialViewResult AddNewBlog()
        {
            return PartialView();
        }

        public PartialViewResult UpdateBlog()
        {
            return PartialView();
        }
        //Blog End


        //About Start

        //About End


        //Contact Start

        //Contact End
        

        //Services Start

        //Services End


        //Comment Start

        //Comment End


        //Category Start

        //Category End
    }
}