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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DrivingSchoolCarId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrivingSchoolId { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
