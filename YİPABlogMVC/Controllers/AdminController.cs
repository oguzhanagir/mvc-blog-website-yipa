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
        AboutManager _aboutManager = new AboutManager();
        NewsletterManager _newsletterManager = new NewsletterManager();
        // GET: Admin
        
        public ActionResult Index()
        {
            return View();
        }

        //Blog Start
        #region
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

        [HttpGet]
        public ActionResult UpdateBlog(int id)
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

            Blog blog = _blogManager.FindBlog(id);
            return View(blog);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateBlog(Blog p)
        {
            _blogManager.UpdateBlog(p);
            return RedirectToAction("BlogList");
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
        #endregion
        //Blog End

        //About Start
        #region
        public ActionResult AboutList()
        {
            var aboutList = _aboutManager.GetAll();
            return View(aboutList);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            About about = _aboutManager.FindAbout(id);
            return View(about);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            _aboutManager.UpdateAbout(p);
            return RedirectToAction("AboutList");
        }


        #endregion
        //About End


        //Contact Start
        #region
        #endregion
        //Contact End


        //Services Start
        #region
        #endregion
        //Services End


        //Comment Start
        #region
        public PartialViewResult CommentCount()
        {
            var commentCount = _commentManager.CommentCount();
            ViewBag.commentCount = commentCount;
            return PartialView();
        }
        #endregion
        //Comment End


        //Category Start
        #region
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
        #endregion
        //Category End

        //Author Start
        #region

        public ActionResult AuthorList()
        {
            var authorList = _authorManager.GetAll();
            return View(authorList);
        }

        public PartialViewResult AuthorCount()
        {
            var authorCount = _authorManager.CountAuthor();
            ViewBag.authorCount = authorCount.ToString();
            return PartialView();
        }
        #endregion
        //Author End

        //Newsletter Start
        #region
        public ActionResult NewsletterList()
        {
            var newsletterList = _newsletterManager.GetAll();
            return View(newsletterList);
        }
        public ActionResult DeleteNewsletter(int id)
        {
            _newsletterManager.DeleteNewsletter(id);
            return RedirectToAction("NewsletterList");
        }
        #endregion
        //Newsletter End
    }
}