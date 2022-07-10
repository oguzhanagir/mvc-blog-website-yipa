using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YİPABlogMVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        // GET: Category
        public ActionResult Index()
        {
           return View();
        }

        public PartialViewResult CategoryList()
        {
            var categoryList = _categoryManager.GetAll();
            return PartialView(categoryList);
        }
    }
}