namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RolePermisstion
    {
        public int RolePermisstionID { get; set; }

        public int? PermisstionID { get; set; }

        public int? RoleID { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
