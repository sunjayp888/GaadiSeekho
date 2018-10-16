namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrivingSchoolRatingAndReview")]
    public partial class DrivingSchoolRatingAndReview
    {
        public int DrivingSchoolRatingAndReviewId { get; set; }

        public int DrivingSchoolId { get; set; }

        public decimal Rating { get; set; }

        [Required]
        public string Review { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
