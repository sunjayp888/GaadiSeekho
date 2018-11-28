using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class StudentQuestionResponse
    {
        public int StudentQuestionResponseId { get; set; }
        public int DrivingSchoolId { get; set; }
        public int StudentId { get; set; }
        public int QuestionId { get; set; }
        public string StudentResponse { get; set; }
        public string CreatedDate { get; set; }
        public virtual Question Question { get; set; }
        public virtual DrivingSchool DrivingSchool { get; set; }
        public virtual Student Student { get; set; }
    }
}
