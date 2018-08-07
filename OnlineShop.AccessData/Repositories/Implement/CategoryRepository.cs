using OnlineShop.AccessData.Repositories.Interface;
using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.AccessData.Repositories.Implement
{
    public class CategoryRepository : RepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(OnlineShopModel context) : base(context)
        {
        }

        public IEnumerable<Category> GetCategories()
        {
            return Get().ToList();
        }
    }
}
