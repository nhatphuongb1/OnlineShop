using OnlineShop.AccessData.Repositories.Interface;
using OnlineShop.Model;

namespace OnlineShop.AccessData.Repositories.Implement
{
    public class ImageRepository : RepositoryBase<Image>,IImageRepository
    {
        public ImageRepository(OnlineShopModel context) : base(context)
        {
        }
        public void AddImage(Image image)
        {
            Insert(image);
            Save();
        }
    }
}
