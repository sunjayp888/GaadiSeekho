using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class FormFour
    {
        public int FormFourId { get; set; }
        public int DrivingSchoolId { get; set; }
        public int StudentId { get; set; }
        public bool IsLMVNT { get; set; }
        public bool IsMCWG { get; set; }
        public bool IsMCWOG { get; set; }
        public bool IsLMVTR { get; set; }
        public bool IsARTR { get; set; }
        public bool IsARNT { get; set; }
        public string DurationOfStayAtPresentAddress { get; set; }
        public string MigratedToIndia { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Student Student { get; set; }
        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
