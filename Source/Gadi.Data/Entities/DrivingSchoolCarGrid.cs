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
        public int DrivingSchoolId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string DrivingSchoolName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DrivingSchoolCarId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(500)]
        public string DrivingSchoolCarName { get; set; }

        [StringLength(100)]
        public string CityMileage { get; set; }

        [StringLength(100)]
        public string ARAIMileage { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string FuelType { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Engine { get; set; }

        [StringLength(100)]
        public string MaxPower { get; set; }

        [StringLength(100)]
        public string MaxTorque { get; set; }

        public int? Seating { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(500)]
        public string EngineDescription { get; set; }

        [StringLength(100)]
        public string TransmissionType { get; set; }

        [StringLength(100)]
        public string CargoVolume { get; set; }

        [StringLength(50)]
        public string WheelType { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DrivingSchoolCarFeeId { get; set; }

        [Key]
        [Column(Order = 8)]
        public decimal WithLicenseFee { get; set; }

        [Key]
        [Column(Order = 9)]
        public decimal WithoutLicenseFee { get; set; }

        public decimal? DiscountAmount { get; set; }

        [StringLength(560)]
        public string SearchField { get; set; }
    }
}
