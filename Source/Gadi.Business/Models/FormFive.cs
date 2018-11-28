using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
   public class FormFive
    {
        public int FormFiveId { get; set; }
        public int DrivingSchoolId { get; set; }
        public int StudentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int EnrollmentNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Student Student { get; set; }
        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
