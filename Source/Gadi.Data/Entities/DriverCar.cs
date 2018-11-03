namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DriverCar")]
    public partial class DriverCar
    {
        public int DriverCarId { get; set; }

        public int DriverId { get; set; }

        public int DrivingSchoolCarId { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual DrivingSchoolCar DrivingSchoolCar { get; set; }
    }
}
