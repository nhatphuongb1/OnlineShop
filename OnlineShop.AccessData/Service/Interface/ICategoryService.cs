using OnlineShop.AccessData.ViewModel;
using System.Collections.Generic;

namespace OnlineShop.AccessData.Service
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> getListCategories(string name, int? parent, bool? status);
        IEnumerable<CategoryViewModel> GetParentCategories();
    }
}
