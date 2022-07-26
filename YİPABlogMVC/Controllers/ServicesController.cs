using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YİPABlogMVC.Controllers
{
    public class ServicesController : Controller
    {
        ServiceManager _serviceManager = new ServiceManager();
        // GET: Services
        public ActionResult Index()
        {
            
            return View();
        }

        public PartialViewResult ServicesContent()
        {
            var serviceList = _serviceManager.GetAll();
            return PartialView(serviceList);
        }

        public PartialViewResult SliderServices()
        {
            var serviceList = _serviceManager.GetAll();
            return PartialView(serviceList);
        }
    }
}