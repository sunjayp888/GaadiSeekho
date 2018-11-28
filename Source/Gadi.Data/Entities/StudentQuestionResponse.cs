namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentQuestionResponse")]
    public partial class StudentQuestionResponse
    {
        public int StudentQuestionResponseId { get; set; }

        public int DrivingSchoolId { get; set; }

        public int StudentId { get; set; }

        public int QuestionId { get; set; }

        [Required]
        [StringLength(500)]
        public string StudentResponse { get; set; }

        [Required]
        [StringLength(10)]
        public string CreatedDate { get; set; }

        public virtual Question Question { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }

        public virtual Student Student { get; set; }
    }
}
