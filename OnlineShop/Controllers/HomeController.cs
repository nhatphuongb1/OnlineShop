using OnlineShop.AccessData.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : BaseController
    {
        private readonly CategoryService categoryService;
        public HomeController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
           // var list = categoryService.getListCategories();
            return View();
        } 
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}