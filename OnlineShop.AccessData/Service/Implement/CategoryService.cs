using AutoMapper;
using OnlineShop.AccessData.Repositories.Interface;
using OnlineShop.AccessData.ViewModel;
using OnlineShop.Model;
using System.Collections.Generic;

namespace OnlineShop.AccessData.Service
{
    public class CategoryService : ICategoryService
    {
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

        public void AddCategory(CategoryViewModel model, string imagePath)
        {
            model.ImageID = imageRepository.AddImage(imagePath);
            Category category = Mapper.Map<Category>(model);
            categoryRepository.AddCategory(category);
        }

        public CategoryViewModel GetCategoryByID(int? id)
        {
            return Mapper.Map<CategoryViewModel>(categoryRepository.GetCategoryByID(id));
        }

        public void EditCategory(CategoryViewModel model, string path)
        {
            Category category = Mapper.Map<Category>(model);
            if (!string.IsNullOrEmpty(path))
            {
                imageRepository.EditImage(model.ImageID, path);
            }
            categoryRepository.EditCategory(category);
        }
    }
}
