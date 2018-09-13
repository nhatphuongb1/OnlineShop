using OnlineShop.Model;
using System.Collections.Generic;

namespace OnlineShop.AccessData.Repositories.Interface
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        IEnumerable<Category> GetCategories(string name,int? parent, bool? status);
        IEnumerable<Category> GetParentCategories();
        void AddCategory(Category category);
    }
}
