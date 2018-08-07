using OnlineShop.AccessData.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        public bool ValidateImage(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                //get extension and convert to lower
                string extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                //check file type
                if (!ConstantValues.LIST_IMAGE_TYPE.Contains(extension))
                {
                    TempData[ConstantValues.STRING_NOTICE_WARNING] = ErrorMessages.INVALID_FILE_FORMAT;
                    return false;
                }
                //check file size
                if (file.ContentLength > ConstantValues.LENGTH_OF_IMAGE)
                {
                    TempData[ConstantValues.STRING_NOTICE_WARNING] = ErrorMessages.INVALID_FILE_SIZE;
                    return false;
                }
            }
            return true;
        }

        public string UploadImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                string filePath = ConstantValues.STRING_UPLOAD + Guid.NewGuid().ToString() + ConstantValues.STRING_SPLASH;

                if (!Directory.Exists(Server.MapPath(filePath)))
                {
                    Directory.CreateDirectory(Server.MapPath(filePath));
                }
                //create path of file
                var path = Path.Combine(Server.MapPath(filePath), fileName);
                file.SaveAs(path);
                return filePath + fileName;
            }
            return null;
        }
    }
}