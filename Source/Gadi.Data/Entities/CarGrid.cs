namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarGrid")]
    public partial class CarGrid
    {
        [Key]
        [Column(Order = 0)]
        public int CarId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(100)]
        public string CityMileage { get; set; }

        [StringLength(100)]
        public string ARAIMileage { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string FuelType { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Engine { get; set; }

        [StringLength(100)]
        public string MaxPower { get; set; }

        [StringLength(100)]
        public string MaxTorque { get; set; }

        public int? Seating { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(500)]
        public string EngineDescription { get; set; }

        [StringLength(100)]
        public string TransmissionType { get; set; }

        [StringLength(100)]
        public string CargoVolume { get; set; }

        [StringLength(630)]
        public string SearchField { get; set; }
    }
}
