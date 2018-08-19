using OnlineShop.AccessData.Service;
using OnlineShop.AccessData.Utilities;
using OnlineShop.AccessData.ViewModel;
using PagedList;
using System.Collections.Generic;
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

        public ActionResult Index()
        {
            BuildCategoryDropDownListForSearch();
            return View();
        }

        public ActionResult _PartialCategory(int? page, string name, int? parent, bool? status)
        {
            ViewBag.name = name;
            ViewBag.parent = parent;
            ViewBag.status = status;
            int pageSize = ConstantValues.PAGE_SIZE;
            int pageNumber = (page ?? 1);
            IEnumerable<CategoryViewModel> list = _categoryService.getListCategories(name,parent,status);
            list = list.ToPagedList(pageNumber, pageSize);
            return PartialView(list);
        }
        public ActionResult _PartialCreate(CategoryViewModel model)
        {
            BuildCategoryDropDownList();
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _PartialCreate(CategoryViewModel model, HttpPostedFileBase file)
        {
            BuildCategoryDropDownList();
            if (ModelState.IsValid)
            {

            }
            return PartialView(model);
        }


        public void BuildCategoryDropDownListForSearch( object selectedValue=null)
        {
            IEnumerable<CategoryViewModel> parentList = _categoryService.GetParentCategories();
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "All",
                Value = null
               
            });
            foreach (var item in parentList)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.CategoryID.ToString()
                });
            }    
            ViewBag.parentForSearch = new SelectList(listItems,"Value","Text", selectedValue);

        }
        public void BuildCategoryDropDownList(object selectedValue = null)
        {
            IEnumerable<CategoryViewModel> parentList = _categoryService.GetParentCategories();
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "---Select parent---",
                Value = null

            });
            foreach (var item in parentList)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.CategoryID.ToString()
                });
            }
            ViewBag.parent = new SelectList(listItems, "Value", "Text", selectedValue);

        }
    }
}