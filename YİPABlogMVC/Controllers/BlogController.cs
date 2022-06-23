using BusinessLayer;
using PagedList;
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

        public PartialViewResult RecentBlogs(int page = 1 )
        {
            var blogList = _blogManager.GetAll().OrderByDescending(x => x.BlogID).ToPagedList(page,3);
            
            return PartialView(blogList);
        }

        public PartialViewResult PopularBlogs(int paged = 1)
        {
            var blogList = _blogManager.GetAll().ToPagedList(paged,6);
            return PartialView(blogList);
        }

        public ActionResult BlogDetails()
        {
            return View();
        }
    


    }
}