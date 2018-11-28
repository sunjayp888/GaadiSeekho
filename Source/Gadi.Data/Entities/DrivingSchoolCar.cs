namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrivingSchoolCar")]
    public partial class DrivingSchoolCar
    {
        public DrivingSchoolCar()
        {
            DrivingSchoolCarFees = new HashSet<DrivingSchoolCarFee>();
            DriverCars = new List<DriverCar>();
        }

        public int DrivingSchoolCarId { get; set; }

        public int DrivingSchoolId { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        public int CarTypeId { get; set; }
        
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

        [StringLength(50)]
        public string WheelType { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }

        public virtual CarType CarType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrivingSchoolCarFee> DrivingSchoolCarFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriverCar> DriverCars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentDrivingDetail> StudentDrivingDetails { get; set; }
    }
}
