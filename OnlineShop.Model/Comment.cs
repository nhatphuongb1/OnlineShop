namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int ID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public int UserID { get; set; }

        public int ProductID { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
