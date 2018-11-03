namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarType")]
    public partial class CarType
    {
        public CarType()
        {
            DrivingSchoolCars = new HashSet<DrivingSchoolCar>();
        }

        public int CarTypeId { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrivingSchoolCar> DrivingSchoolCars { get; set; }
    }
}
