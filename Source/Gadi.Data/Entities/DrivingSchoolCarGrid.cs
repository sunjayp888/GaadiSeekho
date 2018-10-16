namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrivingSchoolCarGrid")]
    public partial class DrivingSchoolCarGrid
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DrivingSchoolCarId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DrivingSchoolId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(500)]
        public string DrivingSchoolName { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CarId { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(500)]
        public string CarName { get; set; }

        [StringLength(100)]
        public string TransmissionType { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal WithLicenseFee { get; set; }

        [Key]
        [Column(Order = 6)]
        public decimal WithoutLicenseFee { get; set; }

        public decimal? DiscountAmount { get; set; }
    }
}
