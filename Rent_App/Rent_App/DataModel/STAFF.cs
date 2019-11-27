namespace Rent_App.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STAFF")]
    public partial class STAFF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STAFF()
        {
            RENTs = new HashSet<RENT>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        public int Role_id { get; set; }

        [Required]
        [StringLength(300)]
        public string FIO { get; set; }

        [Required]
        [StringLength(30)]
        public string Phone_number { get; set; }

        [Required]
        [StringLength(5)]
        public string Gender { get; set; }

        public byte[] Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RENT> RENTs { get; set; }

        public virtual ROLE ROLE { get; set; }
    }
}
