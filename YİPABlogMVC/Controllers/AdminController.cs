using BusinessLayer;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YİPABlogMVC.Controllers
{
    public class AdminController : Controller
    {
        //Manager Class Definition Start
        #region Manager Classes
        BlogManager _blogManager = new BlogManager();
        AuthorManager _authorManager = new AuthorManager();
        CategoryManager _categoryManager = new CategoryManager();
        CommentManager _commentManager = new CommentManager();
        AboutManager _aboutManager = new AboutManager();
        NewsletterManager _newsletterManager = new NewsletterManager();
        ServiceManager _serviceManager = new ServiceManager();
        SocialMediaManager _socialMediaManager = new SocialMediaManager();
        ContactManager _contactManager = new ContactManager();
        #endregion
        //Manager Class Definition End
        // GET: Admin

        public ActionResult Index()
        {
            return View();
        }

        //Blog Start
        #region Blog
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
            if (Request.Files.Count>0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.ImagePath = "/Image/" + dosyaAdi;
            }
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
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.ImagePath = "/Image/" + dosyaAdi;
            }
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
        #region About
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
        #region Contact
        public ActionResult ContactList()
        {
            var contactList = _contactManager.GetAll();
            return View(contactList);
        }
        #endregion
        //Contact End


        //Services Start
        #region Service
        public ActionResult ServiceList()
        {
            var serviceList = _serviceManager.GetAll();
            return View(serviceList);
        }

        public ActionResult DeleteService(int id)
        {
            _serviceManager.DeleteService(id);
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public ActionResult AddNewService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewService(Service p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.ImagePath = "/Image/" + dosyaAdi;
            }
            _serviceManager.AddService(p);
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            Service service = _serviceManager.FindService(id);
            return View(service);
        }

        [HttpPost]
        public ActionResult UpdateService(Service p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.ImagePath = "/Image/" + dosyaAdi;
            }
            _serviceManager.UpdateService(p);
            return RedirectToAction("ServiceList");
        }

        #endregion
        //Services End


        //Comment Start
        #region Comment
        public PartialViewResult CommentCount()
        {
            var commentCount = _commentManager.CommentCount();
            ViewBag.commentCount = commentCount;
            return PartialView();
        }

     
        #endregion 
        //Comment End


        //Category Start
        #region Category
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

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            Category category = _categoryManager.FindCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            _categoryManager.UpdateCategory(p);
            return RedirectToAction("CategoryList","Admin");
        }

        #endregion
        //Category End

        //Author Start
        #region Author

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
        #region Newsletter
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

        //SocialMedia Start
        #region SocialMedia
        public ActionResult SocialMediaList()
        {
            var socialMediaList = _socialMediaManager.GetAll();
            return View(socialMediaList);
        }

        [HttpGet]
        public ActionResult AddNewSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewSocialMedia(SocialMedia p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.IconPath = "/Image/" + dosyaAdi;
            }
            _socialMediaManager.AddSocialMedia(p);
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            _socialMediaManager.DeleteSocialMedia(id);
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            SocialMedia socialMedia = _socialMediaManager.FindSocialMedia(id);
            return View(socialMedia);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.IconPath = "/Image/" + dosyaAdi;
            }
            _socialMediaManager.UpdateSocialMedia(p);
            return RedirectToAction("SocialMediaList");
        }

       


        #endregion
        //SocialMedia End
    }
}