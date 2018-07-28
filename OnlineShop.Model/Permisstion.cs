namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Permisstion
    {
        public int PermisstionID { get; set; }

        [StringLength(50)]
        public string PermisstionName { get; set; }

        public int? RoleID { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
