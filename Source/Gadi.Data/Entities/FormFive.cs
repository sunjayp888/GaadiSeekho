namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormFive")]
    public partial class FormFive
    {
        public int FormFiveId { get; set; }

        public int DrivingSchoolId { get; set; }

        public int StudentId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int EnrollmentNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Student Student { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
