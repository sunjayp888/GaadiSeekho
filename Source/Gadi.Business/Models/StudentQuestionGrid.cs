using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class StudentQuestionGrid
    {
        public int StudentQuestionResponseId { get; set; }
        public int DrivingSchoolId { get; set; }
        public int StudentId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string StudentResponse { get; set; }
        public string CreatedDate { get; set; }
    }
}
