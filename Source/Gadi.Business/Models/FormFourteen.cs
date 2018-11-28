using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class FormFourteen
    {
        public int FormFourteenId { get; set; }
        public int DrivingSchoolId { get; set; }
        public int StudentId { get; set; }
        public int EnrollmentNumber { get; set; }
        public int ClassOfVehical { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string LLRNumber { get; set; }
        public DateTime? EnquiryDate { get; set; }
        public DateTime? PassingDate { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public string RNumber { get; set; }
        public string InwardNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual DrivingSchool DrivingSchool { get; set; }
        public virtual Student Student { get; set; }
    }
}
