using OnlineShop.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace OnlineShop.AccessData.ViewModel
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must between {2} and {1}")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(4000, MinimumLength = 3, ErrorMessage = "Name must between {2} and {1}")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public int ImageID { get; set; }

        public string ImagePath { get; set; }

        public int? ParentID { get; set; }

        [Display(Name = "Parent Name")]
        public string ParentName => CategoryParent.Name;

        [Display(Name = "Status")]
        [Required(ErrorMessage = "{0} is required!")]
        public bool Status { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public Image Image { get; set; }

        public Category CategoryParent {get;set;}

        public HttpPostedFileBase File { get; set; }        

    }
}
