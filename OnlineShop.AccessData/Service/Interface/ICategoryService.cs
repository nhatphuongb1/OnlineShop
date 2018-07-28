using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.AccessData.Service
{
    interface ICategoryService
    {
        List<Category> getListCategories();
    }
}
