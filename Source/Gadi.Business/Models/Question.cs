using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StudentQuestionResponse> StudentQuestionResponses { get; set; }
    }
}
