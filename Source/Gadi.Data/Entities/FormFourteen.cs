namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormFourteen")]
    public partial class FormFourteen
    {
        public int FormFourteenId { get; set; }

        public int DrivingSchoolId { get; set; }

        public int StudentId { get; set; }

        public int EnrollmentNumber { get; set; }

        public int ClassOfVehical { get; set; }

        public DateTime? EnrollmentDate { get; set; }

        [StringLength(100)]
        public string LLRNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EnquiryDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PassingDate { get; set; }

        [StringLength(100)]
        public string DrivingLicenseNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IssueDate { get; set; }

        [StringLength(100)]
        public string RNumber { get; set; }

        [StringLength(100)]
        public string InwardNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }

        public virtual Student Student { get; set; }
    }
}
