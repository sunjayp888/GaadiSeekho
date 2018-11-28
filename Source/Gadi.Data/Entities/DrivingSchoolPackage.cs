namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrivingSchoolPackage")]
    public partial class DrivingSchoolPackage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DrivingSchoolPackage()
        {
            StudentFees = new HashSet<StudentFee>();
        }

        public int DrivingSchoolPackageId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int DrivingSchoolCarId { get; set; }

        public int NumberOfDays { get; set; }

        public decimal Fee { get; set; }

        public decimal Downpayment { get; set; }

        public decimal LumpsumAmount { get; set; }

        public int NumberOfInstallment { get; set; }

        public int DrivingSchoolId { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }

        public virtual DrivingSchoolCar DrivingSchoolCar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentFee> StudentFees { get; set; }
    }
}
