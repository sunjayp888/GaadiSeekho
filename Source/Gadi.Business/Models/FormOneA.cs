using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class FormOneA
    {
        public int FormOneAId { get; set; }
        public int StudentId { get; set; }
        public int DrivingSchoolId { get; set; }
        public string IdentificationMarks1 { get; set; }
        public string IdentificationMarks2 { get; set; }
        public DateTime CreatedDate { get; set; }
        public DrivingSchool DrivingSchool { get; set; }
        public Student Student { get; set; }
    }
}
