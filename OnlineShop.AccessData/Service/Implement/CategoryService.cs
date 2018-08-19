using AutoMapper;
using OnlineShop.AccessData.Repositories.Interface;
using OnlineShop.AccessData.ViewModel;
using OnlineShop.Model;
using System.Collections.Generic;

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

        public IEnumerable<CategoryViewModel> getListCategories(string name, int? parent, bool? status)
        {
            return Mapper.Map<IEnumerable<CategoryViewModel>>(categoryRepository.GetCategories( name,parent,status));
        }

        public IEnumerable<CategoryViewModel> GetParentCategories()
        {
            return Mapper.Map<IEnumerable<CategoryViewModel>>(categoryRepository.GetParentCategories());
        }

    }
}
