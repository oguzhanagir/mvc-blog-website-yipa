using BusinessLayer;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YİPABlogMVC.Controllers
{
    public class AdminController : Controller
    {
        BlogManager _blogManager = new BlogManager();
        AuthorManager _authorManager = new AuthorManager();
        CategoryManager _categoryManager = new CategoryManager();
        CommentManager _commentManager = new CommentManager();
        // GET: Admin
        
        public ActionResult Index()
        {
            return View();
        }

        //Blog Start
        public PartialViewResult BlogList()
        {
            var blogList = _blogManager.GetAll();
            return PartialView(blogList);
        }

        [HttpGet]
        
        public ActionResult AddNewBlog()
        {
            Context c = new Context();

            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;


            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNewBlog(Blog p)
        {
            _blogManager.AddBlog(p);
            return RedirectToAction("BlogList");
        }

        public PartialViewResult UpdateBlog()
        {
            return PartialView();
        }

        public ActionResult DeleteBlog(int id)
        {
            _blogManager.DeleteBlog(id);
            return RedirectToAction("BlogList");
        }

        public PartialViewResult BlogCount()
        {
            var blogCount = _blogManager.BlogCount();
            ViewBag.blogCount = blogCount;
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

        public PartialViewResult CommentCount()
        {
            var commentCount = _commentManager.CommentCount();
            ViewBag.commentCount = commentCount;
            return PartialView();
        }

        //Comment End


        //Category Start
        public ActionResult CategoryList()
        {
            var categoryList = _categoryManager.GetAll();
            return View(categoryList);
        }

        [HttpGet]
        public ActionResult AddNewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewCategory(Category p)
        {
            _categoryManager.AddCategory(p);
            return RedirectToAction("CategoryList");
        }


        public ActionResult DeleteCategory(int id)
        {
            _categoryManager.DeleteCategory(id);
            return RedirectToAction("CategoryList");
        }

        public PartialViewResult CategoryCount()
        {
            var categoryCount = _categoryManager.CategoryCount();
            ViewBag.categoryCount = categoryCount;
            return PartialView();
        }

        //Category End

        //Author Start
        public PartialViewResult AuthorCount()
        {
            var authorCount = _authorManager.CountAuthor();
            ViewBag.authorCount = authorCount.ToString();
            return PartialView();
        }

        //Author End
    }
}