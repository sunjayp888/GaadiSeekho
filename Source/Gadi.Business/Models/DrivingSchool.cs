using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class DrivingSchool
    {
        public int DrivingSchoolId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public int Pincode { get; set; }
        public long Mobile { get; set; }
        public string Telephone { get; set; }
        public string EmailId { get; set; }
        public DateTime CreatedDate { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public decimal? MinimumFeeWithLicense { get; set; }
        public decimal? MinimumFeeWithOutLicense { get; set; }
        public int PersonnelId { get; set; }
        public bool IsTwoWheelerLicense { get; set; }
        public bool IsFourWheelerLicense { get; set; }
        public virtual ICollection<DrivingSchoolCar> DrivingSchoolCars { get; set; }
        public virtual ICollection<DrivingSchoolRatingAndReview> DrivingSchoolRatingAndReviews { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<DriverFeedback> DriverFeedbacks { get; set; }
        public virtual ICollection<StudentDrivingDetail> StudentDrivingDetails { get; set; }
        public virtual ICollection<FormFour> FormFours { get; set; }
        public virtual ICollection<FormFive> FormFives { get; set; }
        public virtual ICollection<FormEight> FormEights { get; set; }
        public virtual ICollection<FormFourteen> FormFourteens { get; set; }
        public virtual ICollection<DrivingSchoolPackage> DrivingSchoolPackages { get; set; }
        public virtual ICollection<StudentFee> StudentFees { get; set; }
        public virtual ICollection<StudentQuestionResponse> StudentQuestionResponses { get; set; }
        public virtual ICollection<FormOneA> FormOneAs { get; set; }
    }
}
