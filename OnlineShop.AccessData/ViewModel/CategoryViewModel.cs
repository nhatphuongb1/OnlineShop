using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.AccessData.ViewModel
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ImageID { get; set; }

        public int? ParentID { get; set; }

        public bool Status { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

    }
}
