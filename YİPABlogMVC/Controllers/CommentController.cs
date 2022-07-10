using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YİPABlogMVC.Controllers
{
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CommentByBlog(int id)
        {
            var commentList = _commentManager.CommentByBlog(id);
            return PartialView(commentList);
        }
    }
}