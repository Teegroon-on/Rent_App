namespace Rent_App.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_SHOP_CENTER
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(200)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Status { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pavilion_col { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string City { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Price { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal Coff_advance_price { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Floor_col { get; set; }
    }
}
