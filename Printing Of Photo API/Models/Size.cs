namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Size: ModelExtension
    {

        public Size()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("size_id")]
        public int SizeId { get; set; }

        [StringLength(50)]
        [Column("size_name")]
        public string SizeName { get; set; }

        [Column("size")]
        [StringLength(20)]
        public string SizeDetails { get; set; }

        [Column("size_price",TypeName = "money")]
        public decimal? SizePrice { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
