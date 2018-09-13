using AutoMapper;
using OnlineShop.AccessData.ViewModel;
using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.AccessData.Mapping
{
    public class AutoMapperConfig
    {
        public static OnlineShopModel context;
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>()
                  .ForMember(dest => dest.Image, opt => opt.MapFrom(src=>src.Image))
                  .ForMember(dest => dest.CategoryParent, opt => opt.MapFrom(src => src.Category2));

                cfg.CreateMap<CategoryViewModel, Category>();
            });
        }
    }
}
