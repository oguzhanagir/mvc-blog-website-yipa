using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YİPABlogMVC.Controllers
{
    public class BlogController : Controller
    {
        BlogManager _blogManager = new BlogManager();
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult RecentBlogs()
        {
            var blogList = _blogManager.GetAll();  //Recent Blogs Methodu Eklenecek Manager Kısmına
            return PartialView(blogList);
        }

        public PartialViewResult PopularBlogs()
        {
            var blogList = _blogManager.GetAll();   //Popular Blogs Methodu Eklenecek Manager Kısmına
            return PartialView(blogList);
        }

        



    }
}