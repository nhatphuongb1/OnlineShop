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
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public List<CategoryViewModel> getListCategories()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category,CategoryViewModel>();
            });
                return Mapper.Map<List<CategoryViewModel >>(categoryRepository.GetCategories());
        }
    }
}
