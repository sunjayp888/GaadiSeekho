namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormEight")]
    public partial class FormEight
    {
        public int FormEightId { get; set; }

        public int DrivingSchoolId { get; set; }

        public int StudentId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TestedAndPassedOn { get; set; }

        [StringLength(100)]
        public string MDLNo { get; set; }

        [StringLength(100)]
        public string MDLFor { get; set; }

        [StringLength(100)]
        public string ValidUpto { get; set; }

        [StringLength(50)]
        public string Age { get; set; }

        [StringLength(100)]
        public string RecommendedMDLNo { get; set; }

        [StringLength(100)]
        public string ToEndrossmentFor { get; set; }

        public decimal? PaidFee { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Student Student { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
