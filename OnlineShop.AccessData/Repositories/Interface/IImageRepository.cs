using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.AccessData.Repositories.Interface
{
    public interface IImageRepository:IRepositoryBase<Image>
    {
        int AddImage(string path);
        void EditImage(int? id, string path);
        Image GetImage(int? id);
    }
}
