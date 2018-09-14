using OnlineShop.AccessData.Repositories.Interface;
using OnlineShop.Model;

namespace OnlineShop.AccessData.Repositories.Implement
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(OnlineShopModel context) : base(context)
        {
        }

        public int AddImage(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                Image image = context.Images.Add(new Image()
                {
                    ImagePath = path
                });
                context.SaveChanges();
                return image.ImageID;
            }
            return 0;

        }

        public void EditImage(int? id, string path)
        {
            Image image = GetImage(id);
            image.ImagePath = path;
            Update(image);
            Save();
        }

        public Image GetImage(int? id)
        {
            return GetByID(id);
        }
    }
}
