using AutoMapper;
using OnlineShop.AccessData.Repositories;
using OnlineShop.AccessData.Repositories.Interface;
using OnlineShop.AccessData.ViewModel;
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
        public OnlineShopModel context;
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IEnumerable<CategoryViewModel> getListCategories()
        {

            return Mapper.Map<IEnumerable<CategoryViewModel>>(categoryRepository.GetCategories());
        }

    }
}
