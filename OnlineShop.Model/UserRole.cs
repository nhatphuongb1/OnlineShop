namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRole")]
    public partial class UserRole
    {
        public int UserRoleID { get; set; }

        public int? UserID { get; set; }

        public int? RoleID { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
