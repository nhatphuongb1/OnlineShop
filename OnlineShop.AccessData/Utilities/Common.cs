using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.AccessData.Utilities
{
    public static class Common
    {
        public static string ConvertToMD5(string password)
        {
            byte[] key = Encoding.UTF8.GetBytes(ConstantValues.SALT);
            byte[] input = Encoding.UTF8.GetBytes(password);
            var hMacMd5 = new HMACMD5(key);
            byte[] resultHash = hMacMd5.ComputeHash(input);
            return Convert.ToBase64String(resultHash);
        }
    }
}
