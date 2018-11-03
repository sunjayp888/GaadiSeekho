namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrivingSchool")]
    public partial class DrivingSchool
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DrivingSchool()
        {
            DrivingSchoolCars = new HashSet<DrivingSchoolCar>();
            DrivingSchoolRatingAndReviews = new HashSet<DrivingSchoolRatingAndReview>();
            DriverFeedbacks = new HashSet<DriverFeedback>();
            Students = new HashSet<Student>();
            Drivers = new HashSet<Driver>();
            CreatedDate = DateTime.UtcNow;
        }

        public int DrivingSchoolId { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Address1 { get; set; }

        [StringLength(500)]
        public string Address2 { get; set; }

        [StringLength(500)]
        public string Address3 { get; set; }

        [StringLength(500)]
        public string Address4 { get; set; }

        public int Pincode { get; set; }

        public long Mobile { get; set; }

        [StringLength(100)]
        public string Telephone { get; set; }

        [StringLength(100)]
        public string EmailId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public decimal? MinimumFeeWithLicense { get; set; }

        public decimal? MinimumFeeWithOutLicense { get; set; }

        public int PersonnelId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrivingSchoolCar> DrivingSchoolCars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrivingSchoolRatingAndReview> DrivingSchoolRatingAndReviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Driver> Drivers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriverFeedback> DriverFeedbacks { get; set; }
    }
}
