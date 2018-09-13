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
        private readonly IImageRepository imageRepository;

        public CategoryService(ICategoryRepository categoryRepository, IImageRepository imageRepository)
        {
            this.categoryRepository = categoryRepository;
            this.imageRepository = imageRepository;
        }

        public IEnumerable<CategoryViewModel> getListCategories(string name, int? parent, bool? status)
        {
            return Mapper.Map<IEnumerable<CategoryViewModel>>(categoryRepository.GetCategories(name, parent, status));
        }

        public IEnumerable<CategoryViewModel> GetParentCategories()
        {
            return Mapper.Map<IEnumerable<CategoryViewModel>>(categoryRepository.GetParentCategories());
        }

        public void AddCategory(CategoryViewModel model)
        {
            Category category = Mapper.Map<Category>(model);
            category.ImageID = 296;
            categoryRepository.AddCategory(category);
        }
    }
}
