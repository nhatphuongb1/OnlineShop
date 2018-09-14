using OnlineShop.AccessData.Service;
using OnlineShop.AccessData.Utilities;
using OnlineShop.AccessData.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Net;
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

        public ActionResult Index(int? page, string name, int? parent, bool? status)
        {
            ViewBag.name = name;
            ViewBag.parent = parent;
            ViewBag.status = status;
            BuildCategoryDropDownListForSearch();
            int pageSize = ConstantValues.PAGE_SIZE;
            int pageNumber = (page ?? 1);
            IEnumerable<CategoryViewModel> list = _categoryService.getListCategories(name, parent, status);
            list = list.ToPagedList(pageNumber, pageSize);
            return View(list);
        }

        public ActionResult _PartialCategory(int? page, string name, int? parent, bool? status)
        {
            ViewBag.name = name;
            ViewBag.parent = parent;
            ViewBag.status = status;
            BuildCategoryDropDownListForSearch();
            int pageSize = ConstantValues.PAGE_SIZE;
            int pageNumber = (page ?? 1);
            IEnumerable<CategoryViewModel> list = _categoryService.getListCategories(name, parent, status);
            list = list.ToPagedList(pageNumber, pageSize);
            return PartialView(list);
        }
        public ActionResult Create()
        {
            BuildCategoryDropDownList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CategoryViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (!ValidateImage(file))
                {
                    ModelState.AddModelError("File", ErrorMessages.INVALID_FILE_FORMAT);
                    BuildCategoryDropDownList();
                    return View();
                }
                model.Status = ConstantValues.ACTIVE;
                model.CreatedAt = DateTime.Now;
                if (file != null)
                {
                    _categoryService.AddCategory(model, UploadImage(file));
                }
                else
                {
                    _categoryService.AddCategory(model, ConstantValues.STRING_DEFAULT_IMAGE);
                }

                return RedirectToAction("index");
            }
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryViewModel model = _categoryService.GetCategoryByID(id);
            BuildCategoryDropDownList(model.ParentID);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(CategoryViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (!ValidateImage(file))
                {
                    ModelState.AddModelError("File", ErrorMessages.INVALID_FILE_FORMAT);
                    BuildCategoryDropDownList(model.ParentID);
                    return View(model);
                }
                model.ModifiedAt = DateTime.Now;
                _categoryService.EditCategory(model,UploadImage(file));

                return RedirectToAction("index");
            }
            BuildCategoryDropDownList(model.ParentID);
            return View(model);
        }


        public void BuildCategoryDropDownListForSearch(object selectedValue = null)
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
            ViewBag.parentForSearch = new SelectList(listItems, "Value", "Text", selectedValue);

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
            ViewBag.parentList = new SelectList(listItems, "Value", "Text", selectedValue);

        }
    }
}