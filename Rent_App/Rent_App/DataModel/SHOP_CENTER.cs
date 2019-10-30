namespace Rent_App.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SHOP_CENTER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHOP_CENTER()
        {
            PAVILION = new HashSet<PAVILION>();
        }

        [Key]
        [StringLength(200)]
        public string Name { get; set; }

        public int Status_id { get; set; }

        public int Pavilion_col { get; set; }

        public int City_id { get; set; }

        public decimal Price { get; set; }

        public decimal Coff_advance_price { get; set; }

        public int Floor_col { get; set; }

        public byte[] Image { get; set; }

        public virtual CITY CITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAVILION> PAVILION { get; set; }

        public virtual STATUS_SC STATUS_SC { get; set; }
    }
}
