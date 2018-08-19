using OnlineShop.AccessData.Repositories.Interface;
using OnlineShop.Model;
using System;
using System.Collections.Generic;

namespace OnlineShop.AccessData.Repositories.Implement
{
    public class CategoryRepository : RepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(OnlineShopModel context) : base(context)
        {
        }

        public IEnumerable<Category> GetCategories(string name, int? parent, bool? status)
        {
            return Get(filter:x=>(String.IsNullOrEmpty(name)|| x.Name.Contains(name))&& 
            (parent == null ||x.ParentID == parent) && (status == null || x.Status == status));
        }

        public IEnumerable<Category> GetParentCategories()
        {
            return Get(filter:x=>x.ParentID==null);
        }
    }
}
