namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DriverFeedbackGrid")]
    public partial class DriverFeedbackGrid
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DriverFeedBackId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DriverId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(500)]
        public string DriverName { get; set; }

        [StringLength(100)]
        public string HasYourDrivingInstructorEverBeenLateForALesson { get; set; }

        [StringLength(100)]
        public string HasYourDrivingInstructorEverMadeYouFeelUncomfortable { get; set; }

        [StringLength(100)]
        public string WouldYouRecommendThisDrivingSchoolToFriends { get; set; }

        [StringLength(100)]
        public string DoYouThinkThisSyllabusWillMakeYouASaferDriver { get; set; }

        public string Comment { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rating { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }
    }
}
