namespace Rent_App.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAVILION")]
    public partial class PAVILION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAVILION()
        {
            RENTs = new HashSet<RENT>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        [Required]
        [StringLength(200)]
        public string SC_name { get; set; }

        public short Floor { get; set; }

        public int Status_id { get; set; }

        public decimal Area { get; set; }

        public decimal Price_for_m { get; set; }

        public decimal Coff_advance_price { get; set; }

        public virtual SHOP_CENTER SHOP_CENTER { get; set; }

        public virtual STATUS_PAVILION STATUS_PAVILION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RENT> RENTs { get; set; }
    }
}
