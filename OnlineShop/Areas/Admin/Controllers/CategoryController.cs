using OnlineShop.AccessData.Service;
using OnlineShop.AccessData.Utilities;
using OnlineShop.AccessData.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index(int? page)
        {
            int pageSize = ConstantValues.PAGE_SIZE;
            int pageNumber = (page ?? 1);
            IEnumerable<CategoryViewModel> list = _categoryService.getListCategories();
            list = list.ToPagedList(pageNumber, pageSize);
            return View(list);
        }

        public ActionResult _PartialCategory(int? page)
        {
            int pageSize = ConstantValues.PAGE_SIZE;
            int pageNumber = (page ?? 1);
            IEnumerable<CategoryViewModel> list = _categoryService.getListCategories();
            list = list.ToPagedList(pageNumber, pageSize);
            return PartialView(list);
        }
    }
}