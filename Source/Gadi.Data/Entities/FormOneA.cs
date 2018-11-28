namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormOneA")]
    public partial class FormOneA
    {
        public int FormOneAId { get; set; }

        public int StudentId { get; set; }

        public int DrivingSchoolId { get; set; }

        [StringLength(500)]
        public string IdentificationMarks1 { get; set; }

        [StringLength(500)]
        public string IdentificationMarks2 { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public DrivingSchool DrivingSchool { get; set; }

        public Student Student { get; set; }
    }
}
