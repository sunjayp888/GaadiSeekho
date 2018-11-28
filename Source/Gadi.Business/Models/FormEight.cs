using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class FormEight
    {
        public int FormEightId { get; set; }
        public int DrivingSchoolId { get; set; }
        public int StudentId { get; set; }
        public DateTime? TestedAndPassedOn { get; set; }
        public string MDLNo { get; set; }
        public string MDLFor { get; set; }
        public string ValidUpto { get; set; }
        public string Age { get; set; }
        public string RecommendedMDLNo { get; set; }
        public string ToEndrossmentFor { get; set; }
        public decimal? PaidFee { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Student Student { get; set; }
        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
