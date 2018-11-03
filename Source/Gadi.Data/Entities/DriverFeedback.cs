namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DriverFeedback")]
    public partial class DriverFeedback
    {
        public int DriverFeedBackId { get; set; }

        public int DriverId { get; set; }

        [StringLength(100)]
        public string HasYourDrivingInstructorEverBeenLateForALesson { get; set; }

        [StringLength(100)]
        public string HasYourDrivingInstructorEverMadeYouFeelUncomfortable { get; set; }

        [StringLength(100)]
        public string WouldYouRecommendThisDrivingSchoolToFriends { get; set; }

        [StringLength(100)]
        public string DoYouThinkThisSyllabusWillMakeYouASaferDriver { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public int DrivingSchoolId { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
