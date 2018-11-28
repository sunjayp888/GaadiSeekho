namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormFour")]
    public partial class FormFour
    {
        public FormFour()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public int FormFourId { get; set; }

        public int DrivingSchoolId { get; set; }

        public int StudentId { get; set; }

        public bool IsLMVNT { get; set; }

        public bool IsMCWG { get; set; }

        public bool IsMCWOG { get; set; }

        public bool IsLMVTR { get; set; }

        public bool IsARTR { get; set; }

        public bool IsARNT { get; set; }

        [StringLength(100)]
        public string DurationOfStayAtPresentAddress { get; set; }

        [StringLength(100)]
        public string MigratedToIndia { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Student Student { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
