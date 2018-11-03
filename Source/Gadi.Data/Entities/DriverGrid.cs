namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DriverGrid")]
    public partial class DriverGrid
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DriverId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(500)]
        public string DrivingLicenceNumber { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime IssuedDate { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime ValidTill { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Mobile { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(500)]
        public string Address1 { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(500)]
        public string Address2 { get; set; }

        [StringLength(500)]
        public string Address3 { get; set; }

        [StringLength(500)]
        public string Address4 { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pincode { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreatedBy { get; set; }

        [Key]
        [Column(Order = 11, TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DrivingSchoolId { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(500)]
        public string DrivingSchoolName { get; set; }

        [StringLength(1560)]
        public string SearchField { get; set; }
    }
}
