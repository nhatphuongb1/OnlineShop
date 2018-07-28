using OnlineShop.AccessData.Repositories;
using OnlineShop.AccessData.Repositories.Interface;
using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.AccessData.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public List<Category> getListCategories()
        {
            return categoryRepository.GetCategories();
        }
    }
}
