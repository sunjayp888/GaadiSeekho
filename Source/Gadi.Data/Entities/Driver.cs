namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Driver")]
    public partial class Driver
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Driver()
        {
            DriverFeedbacks = new HashSet<DriverFeedback>();
        }

        public int DriverId { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string DrivingLicenceNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime IssuedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ValidTill { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public long Mobile { get; set; }

        [Required]
        [StringLength(500)]
        public string Address1 { get; set; }

        [Required]
        [StringLength(500)]
        public string Address2 { get; set; }

        [StringLength(500)]
        public string Address3 { get; set; }

        [StringLength(500)]
        public string Address4 { get; set; }

        public int Pincode { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriverFeedback> DriverFeedbacks { get; set; }
    }
}
