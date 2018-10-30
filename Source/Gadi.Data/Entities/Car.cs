namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public int CarId { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(100)]
        public string CityMileage { get; set; }

        [StringLength(100)]
        public string ARAIMileage { get; set; }

        [Required]
        [StringLength(100)]
        public string FuelType { get; set; }

        public int Engine { get; set; }

        [StringLength(100)]
        public string MaxPower { get; set; }

        [StringLength(100)]
        public string MaxTorque { get; set; }

        public int? Seating { get; set; }

        [Required]
        [StringLength(500)]
        public string EngineDescription { get; set; }

        [StringLength(100)]
        public string TransmissionType { get; set; }

        [StringLength(100)]
        public string CargoVolume { get; set; }
    }
}
