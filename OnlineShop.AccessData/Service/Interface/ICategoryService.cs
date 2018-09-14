using OnlineShop.AccessData.ViewModel;
using OnlineShop.Model;
using System.Collections.Generic;

namespace OnlineShop.AccessData.Service
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> getListCategories(string name, int? parent, bool? status);
        IEnumerable<CategoryViewModel> GetParentCategories();
        void AddCategory(CategoryViewModel model,string imagePath);
        CategoryViewModel GetCategoryByID(int? id);
        void EditCategory(CategoryViewModel category, string path);
    }
}
