namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrivingSchoolFilterGrid")]
    public partial class DrivingSchoolFilterGrid
    {
        [Key]
        [Column(Order = 0)]
        public int DrivingSchoolId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(500)]
        public string Address1 { get; set; }

        [StringLength(500)]
        public string Address2 { get; set; }

        [StringLength(500)]
        public string Address3 { get; set; }

        [StringLength(500)]
        public string Address4 { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pincode { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Mobile { get; set; }

        [StringLength(100)]
        public string Telephone { get; set; }

        [StringLength(100)]
        public string EmailId { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public decimal? MinimumFeeWithLicense { get; set; }

        public decimal? MinimumFeeWithOutLicense { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonnelId { get; set; }

        [Key]
        [Column(Order = 7)]
        public string WorkinDays { get; set; }

        [Key]
        [Column(Order = 8)]
        public string WheelTypes { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(22)]
        public string License { get; set; }

        [Key]
        [Column(Order = 10)]
        public string CarType { get; set; }

        [Key]
        [Column(Order = 11)]
        public string CarName { get; set; }

        [Key]
        [Column(Order = 12)]
        public string SearchField { get; set; }
    }
}
