using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class DrivingSchoolRatingAndReview
    {
        public int DrivingSchoolRatingAndReviewId { get; set; }
        public int DrivingSchoolId { get; set; }
        public decimal Rating { get; set; }
        public string Review { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
