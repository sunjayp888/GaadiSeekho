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
        }

        public int DrivingSchoolCarId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrivingSchoolId { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrivingSchoolCarFee> DrivingSchoolCarFees { get; set; }
    }
}
