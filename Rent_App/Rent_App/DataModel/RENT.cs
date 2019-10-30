namespace Rent_App.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RENT")]
    public partial class RENT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int Renter_id { get; set; }

        public int Staff_id { get; set; }

        public int Status_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Start_rent { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End_rent { get; set; }

        public int? Pavilion_id { get; set; }

        public virtual PAVILION PAVILION { get; set; }

        public virtual RENTER RENTER { get; set; }

        public virtual STAFF STAFF { get; set; }

        public virtual STATUS_RENT STATUS_RENT { get; set; }
    }
}
